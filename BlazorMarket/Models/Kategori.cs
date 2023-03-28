namespace BlazorMarket.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Urun> Urunler { get; set; }

        public Kategori()
        {
            Ad = string.Empty;
            Urunler = new List<Urun>();
        }

        public Kategori(string kategoriAdi) : this()
        { Ad = kategoriAdi; }
    }
}
