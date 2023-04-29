using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTestbank.Data
{
    public class Testbank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Testbank()
        {
            Guid gid = Guid.NewGuid();
            Name = "Testbank_" + gid.ToString().Substring(0, 8);
            Description = "Description for " + Name;
            Questions = new List<Question>();
        }
    }
}
