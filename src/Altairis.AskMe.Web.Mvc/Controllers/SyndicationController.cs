using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using Olbrasoft.AskMe.Business;

namespace Altairis.AskMe.Web.Mvc.Controllers {
    public class SyndicationController : Controller {
        private const int TITLE_MAX_LENGTH = 50;
        private const int DESCRIPTION_MAX_LENGTH = 200;

        private readonly HtmlEncoder _encoder;
        private readonly IQuestions _questions;

        public SyndicationController(HtmlEncoder encoder, IQuestions questions) {
            _encoder = encoder;
            _questions = questions;
        }

        [Route("/feed.rss", Name = "RssFeed")]
        public async Task<IActionResult> RssFeed() {
            var homepageUrl = this.Url.Page("/Index", pageHandler: null, values: null, protocol: this.Request.Scheme);
            var items = await this.GetSyndicationItemsAsync(this.Request.Scheme, 15);

            using (var sw = new StringWriter()) {
                var settings = new XmlWriterSettings {
                    Async = true,
                    Indent = true,
                    Encoding = Encoding.UTF8,
                    OmitXmlDeclaration = true
                };
                using (var xmlWriter = XmlWriter.Create(sw, settings)) {
                    var writer = new RssFeedWriter(xmlWriter);
                    await writer.WriteTitle("ASKme");
                    await writer.WriteDescription("Zeptej se mě na co chceš, já na co chci odpovím");
                    await writer.Write(new SyndicationLink(new Uri(homepageUrl)));
                    await writer.WritePubDate(DateTimeOffset.UtcNow);

                    foreach (var item in items) {
                        await writer.Write(item);
                    }

                    xmlWriter.Flush();
                }
                return File(Encoding.UTF8.GetBytes(sw.ToString()), "application/rss+xml;charset=utf-8");
            }
        }

        private async Task<IEnumerable<SyndicationItem>> GetSyndicationItemsAsync(string protocol, int maxItems)
        {
            var questions = await _questions.GetSyndicationsAsync(maxItems);

            return questions.Select(q => {

                //https://cs.wikipedia.org/wiki/Online_syndikace
                var item = new SyndicationItem {
                    Title = TruncateString(q.QuestionText, TITLE_MAX_LENGTH),
                    Description = this._encoder.Encode(TruncateString(q.QuestionText, DESCRIPTION_MAX_LENGTH)),
                    Id = Url.Page("/Question", pageHandler: null, values: new { questionId = q.Id }, protocol: protocol),
                    Published = q.DateAnswered
                };
                item.AddCategory(new SyndicationCategory(q.CategoryName));
                return item;
            });
        }

        private static string TruncateString(string s, int maxLength) {
            if (s == null) throw new ArgumentNullException(nameof(s));

            if (s.Length >= maxLength) s = s.Substring(0, maxLength) + "...";
            return s;
        }

    }
}
