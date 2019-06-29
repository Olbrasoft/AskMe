using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Altairis.AskMe.Data.Base.Objects
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}