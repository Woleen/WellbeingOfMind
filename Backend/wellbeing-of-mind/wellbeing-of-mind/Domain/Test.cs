using System.ComponentModel.DataAnnotations;
using wellbeing_of_mind.DTOs;

namespace wellbeing_of_mind.Domain
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
