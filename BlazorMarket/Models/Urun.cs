namespace BlazorMarket.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string? Resim { get; set; }

        public Urun()
        {
            Ad = string.Empty;
        }

        public Urun(string urunAdi, string urunResim)
        {
            Ad = urunAdi; Resim = urunResim;
        }
    }
}
