namespace BlazorTestbank.Models
{
    public class Testbank
    {
        public int Id { get; set; }
        public Guid TbGuid { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }

        public string Description { get; set; }

        public Testbank()
        {
            TbGuid = Guid.NewGuid();
            Name = "Testbank_" + TbGuid.ToString().Substring(0,8);
            Description = "Description for " + Name;
            Selected = false;
        }
    }
}
