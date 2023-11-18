using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wellbeing_of_mind.Domain
{
    public class Choice
    {
        [Key]
        public int Id {  get; set; }
        public string ChoiceContent { get; set; }

        public int ChoiceWeight { get; set; }
        public Question Question { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; } 
        
    }
}