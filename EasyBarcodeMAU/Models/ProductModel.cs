namespace EasyBarcodeMAU.Models;
    public class ProductModel : BaseViewModel {


        public List<ProductItemBase> MyItems { get; set; } = new List<ProductItemBase>
        {
            new ProductItemBase { Id = 1, DefterNo = 123321456, DepoGirisi = DateTime.Now, MusteriAd = "Beko", UrunCins = "Beyaz Eşya", UrunAdet = 150, UrunAgirlik = 1000 , DepoKonum = "Istanbul" },
            new ProductItemBase { Id = 2, DefterNo = 451321512, DepoGirisi = DateTime.Now, MusteriAd = "Penta Teknoloji", UrunCins = "Ekran Kartı", UrunAdet = 500, UrunAgirlik = 5000 , DepoKonum = "Bursa" },
            new ProductItemBase { Id = 3, DefterNo = 561321512, DepoGirisi = DateTime.Now, MusteriAd = "Vatan Computer", UrunCins = "Mouse", UrunAdet = 600, UrunAgirlik = 300 , DepoKonum = "İzmir" },
            new ProductItemBase { Id = 4, DefterNo = 561321512, DepoGirisi = DateTime.Now, MusteriAd = "Teknosa", UrunCins = "Laptop", UrunAdet = 600, UrunAgirlik = 9000 , DepoKonum = "Erzurum" },
            new ProductItemBase { Id = 5, DefterNo = 671321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 300, UrunAgirlik = 250 , DepoKonum = "Malatya" },
            new ProductItemBase { Id = 6, DefterNo = 781321512, DepoGirisi = DateTime.Now, MusteriAd = "Hepsiburada", UrunCins = "Kitap", UrunAdet = 1000, UrunAgirlik = 250 , DepoKonum = "Malatya" },
            new ProductItemBase { Id = 7, DefterNo = 891321512, DepoGirisi = DateTime.Now, MusteriAd = "Getir", UrunCins = "Kulaklık", UrunAdet = 400, UrunAgirlik = 2000 , DepoKonum = "Malatya" },
        };
    }