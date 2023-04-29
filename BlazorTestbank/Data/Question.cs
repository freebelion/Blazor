using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorTestbank.Data
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string HtmlContent { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }

        public Question()
        {
            HtmlContent = "<b>Question_" + Id.ToString() + "</b> Html Content";
            Choices = new List<Choice>();
        }
    }
}
