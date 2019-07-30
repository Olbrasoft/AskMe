using System.ComponentModel.DataAnnotations;
using Altairis.AskMe.Data.Base.Objects;
using AutoMapper;

namespace Altairis.AskMe.Data.Transfer.Objects
{
    [AutoMap(typeof(Question), ReverseMap = true)]
    public class InputQuestionDto
    {
        [Required(ErrorMessage = "Není zadána otázka"), MaxLength(500), DataType(DataType.MultilineText)]
        public string QuestionText { get; set; }

        [MaxLength(100)]
        public string DisplayName { get; set; }

        [MaxLength(100), DataType(DataType.EmailAddress, ErrorMessage = "Nesprávný formát e-mailové adresy")]
        public string EmailAddress { get; set; }

        public int CategoryId { get; set; }
    }
}