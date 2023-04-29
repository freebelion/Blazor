using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorTestbank.Data
{
    public class Choice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string HtmlContent { get; set; }

        public Choice()
        {
            HtmlContent = "<i>Choice</i>";
            HtmlContent = string.Empty;
        }
    }
}
