using System.Text;

namespace MyEmptyBlazorApp1.Models
{
    public class Hisse
    {
        private static Random rnd = new Random();
        private static int hisseNo = 0;

        public int Id { get; set; }
        public string? Kod { get; set; }
        public double Fiyat { get; set; }

        // Kurucu fonksiyon Id için otomatik artan değer belirliyor,
        // varsa kod ve fiyat için gelen ilk değerleri atıyor.
        public Hisse(string? hisseKodu = null, double hisseFiyatı = 0)
        {
            hisseNo++;
            Id = hisseNo;

            Kod = hisseKodu;
            Fiyat = hisseFiyatı;
        }

        // Rasgele bir kod ve fiyat ile Hisse nesnesi oluşturan fonksiyon

        public static Hisse RasgeleHisse()
        {
            return new Hisse(RasgeleKod(5), Math.Round(10.0 + 90.0 * rnd.NextDouble(), 2));
        }

        // esin kaynağı: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
        private static string RasgeleKod(int harfSayisi)
        {
            StringBuilder rndkod = new StringBuilder();
            char ilkHarf = 'A';

            for(int i=0; i < harfSayisi; i++)
            {
                char harf = (char) rnd.Next(ilkHarf, ilkHarf + 26);
                rndkod.Append(harf);
            }

            return rndkod.ToString();
        }
    }
}
