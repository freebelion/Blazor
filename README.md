Bu projeler grubu altında "Blazor Server App" şablonuyla
bazı deneme uygulamaları oluşturuyorum.
Bu belgeyi de *güya* benim gibi yeni öğrenenlere
yardım etmek için oluşturdum.
> *Asıl niyetim kendi keşif yolculuğum için bir günlük tutmak.*

Buradaki amacım daha alışık olduğum .NET platformu üzerinde,
iyi bildiğim C# programlama diliyle tek sayfalık web uygulamaları
(*single page web applications*) oluşturmak.

Bu gruptaki hemen hemen her projeyi **"Blazor Server App Empty"**
(Blazor Server Boş Uygulama) kalıbıyla oluşturacağım:

![](/Resimler/Resim1.png "Blazor Server Boş Uygulama kalıbının seçimi")

Dikkat etmişsinizdir, "blazor" terimiyle yaptığım arama sonucunda
"Boş" (*Empty*) olmayan Blazor uygulaması kalıpları da var.
Bunlar belli bir iskelet üzerinde geçici içerikler sunacaklardır.
yeni başlayan birisi için öylesi daha faydalı olacak sanabilirsiniz,
ama iş kendi içeriğinizi kendi düzeninizle sunmaya gelince,
o kurulum iskeleti ve geçici içerikleri silmekle uğraşmanız gerekebilir.
Öylesi benim işime gelmediği için, boş kalıpla başlamayı tercih ettim.

# EmptyBlazorApp1

Bu seçimle oluşturduğum ilk uygulama için Visual Studio
**"EmptyBlazorApp1"** ismini seçti, ben de bu ve sonraki seçimlerin
hepsini sorgusuz kabul ettim.
> *Keşif yapıyorsam da her adımda yeni bir macera arıyor değilim.*

## Açılış Sayfası

Projede neyin nerede olduğuna bile bakmadan
CTRL+F5 ile Release modunda uygulamayı çalıştırdığımda,
önce geçici bir web sunucusunu başlatan komut penceresi açıldı,
sonra da "boş" uygulamanın sunduğu geçici içeriği
görüntüleyen bir web sayfası gördüm:

![](/Resimler/Resim2.png "Blazor Server Boş Uygulamasının ilk açılışı")

Bu standartlaşmış "Hello, world!" içeriği uygulamın "başlangıç sayfası"
diyebileceğimiz **Index.razor** sayfasından gelmiştir:

```
@page "/"

<h1>Hello, world!</h1>
```

Evet, sayfa içeriğinde HTML var, ama bu bir HTML sayfası değil,
bir "razor" sayfasıdır. İçeriğinde HTML harici kodlar da yer alabilir.
Örneğin, ilk satırdaki bildirim bu sayfanın uygulamanın kök (*root*)
sayfası olduğunu, alt sayfa adresi verilmemişse bu sayfanın
görüntüleneceğini belli ediyor.

### *Esrarengiz kenarlık hakkında*
Ama açılış sayfasındaki geçici içerik etrafında bir kenarlık vardı
(bkz. bir üstteki resim); acaba o nereden geldi?
Bu konuda sorulmuş bir
[soruya verilen cevaba](https://www.reddit.com/r/Blazor/comments/xl09d8/blazor_h1_element_is_focused_on_startup_for_no/)
göre, Blazor uygulaması görüntülediği sayfadaki **h1** öğesine
odaklanmıştı. Bunu yapan komut da uygulamanın "başlangıç kod dosyası"
diyebileceğimiz **App.razor** içindeydi:
```
<Router AppAssembly="@typeof(App).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
    <NotFound>
        <PageTitle>Not found</PageTitle>
        <LayoutView Layout="@typeof(MainLayout)">
            <p role="alert">Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```
Bulduğum cevapta önerildiği gibi,
**<FocusOnNavigate** ile başlayan kod satırını silerek
istemediğim kenarlıktan kurtuldum.

Bu vesileyle göz attığınız **App.razor** dosyasının kalan içeriğini
merak etmişseniz, `<Found Context=routeData>` kod bloku
uygulamanın tanıdığı bir adres görmesi durumunda ne yapacağını,
`<NotFound>`kod bloku da geçersiz bir adresle karşılaşması durumunda
ne yapacağını söylüyor.
> *Ben bu ilk uygulamamda bunlara dokunmadan geçiyorum.*

## Bootstrap Stillerinin Kullanımı

Her nedense Bootstrap stil kütüphanesini kullanmayı
pek sevdiğim için, Blazor uygulamalarımda da kullanmayı
denedim. Bunun için "uygulama sayfalarının HTML tabanı"
diyebileceğimiz **_Host.cshtml** sayfasına gerekli linki
koydum:
`<link href="css/bootstrap.css" rel="stylesheet" />`
> *Ben denemelerimi çevrimdışı yaptığım için
   kendi indirdiğim bootstrap.css dosyasını
   projenin **css** klasörüne ekledim ve
   onu gösteren bir link koydum.
   Siz isterseniz çevrimiçi bir bootstrap kaynağına link ekleyin.*

Yukarıda sözünü ettiğim **.cshtml** dosyasında
projenin **css** klasöründeki bir
**site.css** stil dosyasının da linki vardı.
O dosyaya uygulama sayfalarında kullanacağınız
kendi stil tanımlarınızı koyabilirsiniz.

## Açılış Sayfası İçeriğinin Düzenlenmesi

Açılış sayfası **index.razor** içeriğini aşağıdaki gibi değiştirdim:

```
@page "/"

<div class="container mt-5 bg-primary rounded border border-dark">
    <h1 class="m-5 display1 text-light">Blazor Uygulama Denemesi</h1>
</div>
```

Deneme çalıştırmasında sayfa şu şekilde gözüktü:

![](/Resimler/Resim3.png "Blazor Server Boş Uygulamasının ikinci açılışı")

Bu ilk denemeyi daha ileriye götürmeden,
bu haliyle bırakmaya karar verdim.
Kodlar da içeren daha "işe yarar" uygulamalar geliştirken
artık bu ön adımları açıklamaya gerek duymayacağım.

## Kişisel Proje Kalıbı Oluşturulması

Yukarıda anlattığım ilk adımları bundan sonraki projelerde
uygulamamak için bu projeye dayalı yeni bir kişisel kalıp
(*template*) oluşturmak mantıklı olacaktı.

Visual Studio ortamında **Project** (Proje) menüsünden
**"Export Template"** (Kalıp Oluştur? Sür?) seçeneğini
tercih ederek yeni kalıbın dayalı olacağı bu ilk projeyi seçtim:

![](/Resimler/Resim4.png "İlk projenin yeni proje kalıbı olarak seçilmesi")

Sonra da bir isim ve açıklama ekleyerek yeni proje kalıbını oluşturdum:

![](/Resimler/Resim5.png "Yeni proje kalıbı oluşturulması")

# MyEmptyBlazorApp1

Bu projeyi ilk projeye dayalı kişisel proje kalıbıyla oluşturdum:

![](/Resimler/Resim6.png "Yeni proje kalıbıyla proje oluşturulması")

> *Evet, proje kalıbına sözcükler arasında boşlukları olan
bir isim koymalıydım, ama geçti artık.*

Oluşturduğum proje kalıbının ilk örneği olduğu için
başlıktaki ismi aldı; her zamanki uysallığımla ismi
değiştirmeden kabul ettim.

**EmptyBlazorApp1** için yapmış olduğum tüm değişiklikler
bu projede aynen yer alıyordu. Hatta **bootstrap.css** dosyasıda
zaten projeye dahildi.
> Ama bir sorun vardı: Proje kalıbıyla gelen 
  **_Imports.razor** dosyasında eski projenin referansı
  hala duruyordu:<br>
  `@using EmptyBlazorApp1`<br>
  Bunu yeni proje adına referans yapacak şekilde
  değiştirdim:<br>
  `@using MyEmptyBlazorApp1`

## Nesne Sınıfları için Klasör Eklenmesi

Bu proje örneğiyle geliştireceğim uygulama
hayali hisse senetlerini listeleyecek.

Hayali hisse senetlerini temsil edecek bir sınıf tanımı
oluşturmakla işe başlayacağım.
Ama ondan da önce, bu sınıf tanımını koymak için
yeni bir proje klasörü oluşturmalıyım.

Hiç bilmeyenler için: Projeye klasör eklemek şöyle yapılıyor:

![](/Resimler/Resim7.png "Projeye klasör eklenmesi")

Teamüller gereği :-) bu proje klasörüne **"Models"** ismini verdim,
çünkü nesne modellerini içerecek.
Yani, tamam, tek bir model olacak içinde, ama olsun,
maksat işin raconuna uymak.
> Bu proje klasörüne ekleyeceğim sınıf tanımları
  projenin kendi ad uzayında (*namespace*) değil,
  klasör adını taşıyan bir alt ad uzayında olacaktır.
  O tanımları kodlarda kullanırken de bu alt uzay adını da
  eklemek gerekecekti.<br>
  Onun yerine, yukarıda sözünü ettiğim
  **_Imports.razor** dosyasına
  gerekli referansı kendim ekledim:<br>
  `@using Models`

## Nesneleri Temsil Edecek Sınıf Tanımı Eklenmesi

Artık sıra hayali hisseleri temsil edecek sınıf tanımını
eklemeye geldi.
Bu tanımı az önce oluşturduğum "Models" klasörüne ekledim:

![](/Resimler/Resim8.png "Models klasörüne sınıf tanımı eklenmesi")

Bu yeni sınıfın kod dosyası için önerilen geçici isim **Class1.s**
yerine kendi düşündüğüm **Hisse.cs** ismini uygun gördüm.

İşi basit tutmak için, daha önce bulduğum
[bir örnekteki](https://learn.microsoft.com/en-us/aspnet/core/blazor/tutorials/build-a-blazor-app?view=aspnetcore-7.0&pivots=server)
gibi, sınıf tanımına yalnızca hayali hissenin kodunu ve fiyatını
belirleyecek otomatik özellikler (*auto properties*) ekledim:

```
namespace MyEmptyBlazorApp1.Models
{
    public class Hisse
    {
        public int Id { get; set; }
        public string? Kod { get; set; }
        public double Fiyat { get; set; }
    }
}
```

Ben sınıf tanımını oluştururken "akıllı tamamlayıcı"
(*Intellisense* için uydurduğum isim)
**Id** adlı tamsayı özellik tanımını otomatik ekledi,
ben de yine uysallaşıp kabul ettim.
Ama bunu boşuna yapmadım; gelecekte model sınıfları
veri tablosu kayıtlarına dönüştüreceğimiz zaman
bu **Id** bilgisi otomatik artan "anahtar değer"
olarak işe yarayacaktır.

> Bilmeyenler için:
  (zaten bilenlerin burada ne işi olabilir ki?)<br>
  Hisse kodunun belirtilmediği durum olabileceği
  için, **Kod** özelliğinin türü **string?** olarak gözüküyor,
  yani boş adres (**null**) alabilecek bir referans değişkeni.

Ben bu ilkel projede veri tablosu kullanmadığım için
**Id** için otomatik değer atamayı kendim hallettim:

```
    // Kurucu fonksiyon Id için otomatik artan değer belirliyor,
    // varsa kod ve fiyat için gelen ilk değerleri atıyor.
    public Hisse(string? hisseKodu = null, double hisseFiyatı = 0)
    {
        hisseNo++;
        Id = hisseNo;

        Kod = hisseKodu;
        Fiyat = hisseFiyatı;
    }
```

## Index.razor Sayfasına Kodlar Eklenmesi

**Hisse** sınıfı türünden yeni bir nesne oluşturmak
için `new Hisse()` şeklinde bir komut yetecektir.
Böyle bir komut hisse kodu veya fiyatı için 
ilk değer göndermediği için kurucu fonksiyon
varsayılan ilk değerleri kullanacak,
yani **Kod** özelliğini boş (**null**) bırakacak,
**Fiyat** için de sayısal değer 0 olacak.

Ama istersek `new Hisse(AGAWC, 100)` şeklinde bir komutla,
kodunu ve fiyatını belirlediğimiz bir hisse nesnesi de
oluşturabiliriz.

Sorun şu ki, **Hisse** nesnelerini oluşturan kodları
nereye koyacağız? Bir .NET konsol uygulaması geliştiriyor
olsaydık, programın giriş noktası **Program.cs** adlı
kod dosyasındaki **Main** adlı fonksiyon olurdu.
Burada onlar yok. Asıl sunumu **.razor** uzantılı sayfalar
yapacak, ama onlar da HTML içeriğini oluşturmak için.

Ama sıkı durun: **.razor** uzantılı sayfalara içeriğini
oluşturacak kodları da ekleyebiliriz.

Sayfa dosyasının altına ekleyeceğimiz
```
@code {
    
}
```

bloku içinde değişken ve fonksiyon tanımları olabilir.

Şimdilik yalnızca deneme yaptığımız için
biz hisse nesneleri oluşturacak kodları
doğrudan ana sayfaya, yani **Index.razor** dosyasına ekledik:

```
@code {
    private List<Hisse> hisseler = new();

    public void HisseEkle()
    {
        hisseler.Add(Hisse.RasgeleHisse());
    }
}
```

Bu **@code** blokunda **Hisse** türü nesnelerin bir jenerik listesi
tanımlanmış, ve evet, bu liste tür belirtmeyen bir `new()`
çağrısıyla oluşturuluyor.

`HisseEkle()` adlı fonksiyon da bu listeye 
yeni bir **Hisse** nesnesi eklemek için.
Bu fonksiyon yeni hisseyi rasgele bir kod ve fiyat ile
oluşturan bir **static** fonksiyonu kullanıyor.
O fonksiyonu **Hisse.cs** kod dosyasında görebilirsiniz.
> *O fonksiyon hakkında ayrıntıya girmeyeceğim;
  konumuzun dışında kalıyor çünkü.*

## Index.razor Sayfasından Fonksiyon Çağrılması

Bu uygulama hisse senetlerinin bilgilerini
gerçek borsa verilerinden çekip almayacak;
ana sayfadaki bir düğme her tıklandığında
rasgele kod ve fiyatı olan
hayali bir hisse nesnesi oluşturacak.

Bu düğme tanımını **Index.razor** dosyasındaki
container türü div öğesinin içine yerleştirdik:
```
<div class="container mt-5 bg-primary rounded border border-dark">
    <h1 class="m-5 display1 text-light">Blazor Borsa Uygulaması</h1> 

    <button type="button" class="btn btn-light border rounded border-dark m-5"
            @onclick="HisseEkle">
        Hisse Ekle
    </button>

</div>
```

Tıklama olayını yanıtlayan fonksiyon referansına
dikkat edin: **.razor** sayfalarında
her türlü kod referansı **@** sembolüyle başlar.

## Index.razor Sayfasında Nesnelerin Listelenmesi

Ve artık sona geldik: **hisseler** adlı jenerik listedeki
nesneleri listeletmek için<br>
`@foreach (var hisse in hisseler)`<br>
şeklinde bir döngü açmalıyız.

Bu döngü içinde her **Hisse** nesnesini Bootstrap'in tanımladığı
card türü bir öğe içinde görüntülüyoruz.
Nesneye veya özelliklerine referans yaparken de
hep o **@** sembolünü kullanıyoruz:

```
<div class="container mt-5 bg-primary rounded border border-dark">
    <h1 class="m-5 display1 text-light">Blazor Borsa Uygulaması</h1> 

    <div class="row">
        @foreach (var hisse in hisseler)
        {
            <div class="card col-md-2 m-2">
                <h2 class="card-title m-2">@hisse.Kod</h2>
                <h3 class="card-footer m-2">@hisse.Fiyat</h3>
            </div>
        }
    </div>

    <button type="button" class="btn btn-light border rounded border-dark m-5"
            @onclick="HisseEkle">
        Hisse Ekle
    </button>

</div>
```

Bu eklemeleri de yapıp uygulamayı çalıştırırsanız
hayali hisse senetlerinin aşağıdaki resimdeki
gibi sıralandıklarını göreceksiniz:

![](/Resimler/Resim9.png "Hayali hisse senetlerinin listelenmesi")

## MyEmptyBlazorApp2

Bu denememde de ilk denememizde oluşturduğum
kendi boş uygulama kalıbımı kullandım.

Bu kez hayali ürünleri listeleyecek bir uygulama geliştirecektim.
Yine bir "Ekle" düğmesiyle ürün eklemek niyetindeydim,
ama eklenen ürün adı ve fiyatını kendim girecektim.

Bunu önceki uygulamadaki gibi yapabilirdim;
tek yapmam gereken şey ürün adı ve fiyatını başlık öğelerinde
görüntülemek yerine elle bilgi girişine izin veren
**input** öğelerinde göstermekti.
Blazor'ın **@bind** direktifi sayesinde **input** öğelerinde
girilen bilgiler ürün adları ve fiyatlarına yansıyacaktı.

### Alt Öğeler (Component) Ne İşe Yarar

Ama şöyle de bir durum vardı:
Ürün bilgi girişi için belki şimdi sade metin kutuları
yeterli olabilir, ama ya ileride bilgi giriş için farklı
yollar kullanmaya karar versem ne olacaktı?
O zaman bu uygulamanın ana sayfası **Index.razor**
içeriğinde ürün ayrıntılarını görüntüleyen öğeleri
yeniden düzenlemem gerekecekti.
Bu da kolay, ama ya başka uygulamalarda da ürün ayrıntılarını
gösterecek öğeler kullanmaya kalsam ne olacaktı?

İşte işi doğru yapmanın sırrı bu son cümlede gizliydi.
Hisse ya da Ürün, ya da başka bir şey,
gerçek hayatta birden fazla uygulamada ayreıntılarını
düzenleme gereği hissedeceğim nesneleri görüntülemek
için kendi tasarladığım öğeleri kullanmam daha doğru olurdu.

Böylece, ayrıntıları görüntüleyecek veya düzenleme imkanı
sunacak öğelerim önceden hazır olurdu ve onları gelecek
uygulamalarımda da kullanırdım. Bu alt öğelerin görünümü
hakkında değişiklikleri yalnızca o öğeleri temsil eden
kod dosyalarında yapardım ve onları hazır kullanan
uygulamaların hepsini tekrar değiştirmem gerekmezdi.

Blazor Server uygulamalarında böyle bir öğe oluşturmak
için projeye bir "Razor Component" ekleriz.
Bu işlemle .razor uzantılı yeni bir dosya eklemiş
oluruz, ama bu yeni öğe bir Razor sayfası değil,
parametre alabilen bir alt öğedir.

### Projeye Alt Öğe (Component) eklenmesi

İşte bu nedenle, hayali ürünleri temsil edecek
Urun sınıfının yanında, bir de onun ayrıntılarını
görüntüleyecek bir alt öğe eklemeye karar verdim.

Bu projeye de model sınıfları barındıracak
"Models" adlı bir klasör ekledim.
Ürünleri temsil edecek **Urun** sınıf tanımını
bu klasöre eklediğim **Urun.cs** dosyasına koydum:

```
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
```
Projenin "Pages" klasörüne de ürün ayrıntılarını görüntüleyecek
bir alt öğe ekledim. Yeni bir proje öğesi eklemek için
"Pages" klasör simgesi üzerinde "Add" > "New Item"
menü seçeneklerini izledikten sonra "Razor Component" seçeneğini
tercih ettim ve bu alt öğeye uygun bir isim koydum:
![](/Resimler/Resim10.png "Ürün ayrıntılarını görüntüleyecek alt öğe eklenmesi")

### UrunDetay.razor Öğesinin Düzenlenmesi

Bu işlem sonucunda, alt öğe için **UrunDetay.razor** kod dosyasını
eklemiş oldum.
Bu dosyanın kod içeriğini önceki uygulamada hisse bilgilerini
görüntüleyen "card" türü öğeler gibi oluşturdum:
```
<div class="col-md-3">
    <div class="card m-2">
        <h2 class="card-title m-2"><input @bind="goruntulenenUrun.Ad" /></h2>
        <h3 class="card-footer m-2"><input @bind="goruntulenenUrun.Fiyat" /></h3>
    </div>
</div>
```
ama görüntülemenin yanında bilgi girişine de izin verecek
**input** öğeleri kullandım.

Bu **input** öğeleri **@bind** direktifleriyle
alt öğenin görüntüleyeceği ürünün
**Ad** ve **Fiyat** bilgilerine bağlıydılar.

Ama **goruntulenenUrun** nedir? Bu alt öğe onu dışarıdan
bir referans olarak almalıdır.
Bu referans bildirimi **UrunDetay.razor** dosyadındaki
**@code** bölümündedir:

```
@code {
    [Parameter]
    public Urun goruntulenenUrun { get; set; }
}
```

### UrunDetay Öğelerinin Ana Sayfada Kullanılması

Peki bu parametre nereden gelecek?<br>
Bu nokta çok önemlidir aslında,
çünkü -denemişseniz görmüşsünüzdür-
Visual Studio UrunDetay.razor kod dosyasında
bu referans değişkeninin kaynağı belirsiz diye uyarı veriyordu:

![](/Resimler/Resim11.png "UrunDetay öğesindeki belirsiz referans uyarısı")

Bu uyarıyı ortadan kaldıracak bir önlem almadım ben,
çünkü her bir **UrunDetay** öğesi için görüntüleyeceği ürünün
referansı uygulamanın ana sayfasından gelecek.
Öyle biliyorum, çünkü öyle yapacağım.

Önceki denememdeki gibi, bu denemem için de
uygulama ana sayfasında hayali ürünleri temsil edecek
**Urun** türü nesneler listesi tanımlamıştım.
Yine tıklanınca yeni ürün oluşturup ekleyecek olan
bir düğmem vardı. Ama bu kez ürünleri doğrudan sayfa içinde
görüntülemiyordum. Onun yerine, her bir ürünün görüntüleme
işini bir **UrunDetay** öğesine bırakıyordum.
Parametre aktarımı işte o alt öğelerde gizlidir:

```
    @foreach (var urun in urunler)
    {
        <UrunDetay goruntulenenUrun="@urun" />
    }
```

Gördüğünüz gibi, projeye eklediğim bu öğeyi
tıpkı bir HTML öğesi gibi kullanıyorum.
Uygulama **urunler** listesindeki her bir
eleman için bir `<UrunDetay/>` öğesi
oluşturuyor. O öğeye de görüntülemekle
sorumlu olduğu **urun** elemanının referansını aktarıyor.

Diğer ayıntıları burada tekrarlamayacağız.
Liste oluşturulması veya yeni nesne eklenmesi
aynı önceki uygulamadaki gibiydi.

### Input Öğeleri için Stil Tanımlanması

Bu uygulamada farklı yaptığım tek şey,
bilgi girişi için kullandığım **input** öğelerinin
görünümünüyle ilgiliydi.

Metin kutuları içinde oldukları
**div** bölümlerinin dışına taşıyorlardı.
Bootstrap form öğesi stillerini kullanarak 
daha düzgün görünmelerini sağlayabilirdim.
Onun yerine, yaptığım arama sonucunda bulduğum
[bir cevapta](https://stackoverflow.com/questions/1633522/html-input-element-wider-than-containing-div)
önerilen yöntemi kullandım.

Uygulama sayfalarında kullanılacak ortak stillerin
tanımlandığı site.css dosyasına bütün input öğeleri
için geçerli olacak şu stil tanımını ekledim:

```
input {
    padding: 0.2em;
    box-sizing: border-box;
    width: 100%
} 
```

Çalıştırığım zaman uygulama aşağıdaki gibi gözüküyordu;
eklemeler ve düzenlemeler bile yaptım:

![](/Resimler/Resim12.png "Bilgi girişine izin veren ürün listeleme uygulaması")