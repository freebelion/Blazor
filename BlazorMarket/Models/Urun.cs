namespace BlazorMarket.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }

        public Urun()
        {
            Name = string.Empty;
        }
    }
}
