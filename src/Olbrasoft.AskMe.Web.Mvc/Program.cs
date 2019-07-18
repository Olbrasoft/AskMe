using Olbrasoft.AskMe.Web.Mvc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Olbrasoft.AskMe.Web.Mvc {
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseUrls("http://0.0.0.0:5001")
                .Build();
    }
}
