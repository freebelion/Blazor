namespace BlazorMarket.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Urun> Urunler { get; set; }

        public Kategori()
        {
            Name = string.Empty;
            Urunler = new List<Urun>();
        }
    }
}
