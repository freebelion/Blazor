namespace MyEmptyBlazorApp2.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public double Fiyat { get; set; }

        // "Ad" özelliğinin türü string? değil, yani null değeri alamaz.
        // yani boş kurucu fonksiyonda hiç değilse boş bir string almalı.
        public Urun()
        {
            Ad = string.Empty;
            Fiyat = 0;
        }
    }
}
