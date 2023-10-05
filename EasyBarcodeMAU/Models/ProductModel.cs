namespace EasyBarcodeMAU.Models {
    public class ProductModel : BaseViewModel {


        public List<ProductItemBase> MyItems { get; set; } = new List<ProductItemBase>
        {
            new ProductItemBase { Id = 1, DefterNo = 123321456, DepoGirisi = DateTime.Now, MusteriAd = "Beko", UrunCins = "KALEM", UrunAdet = 7839858, UrunAgirlik = 195 , DepoKonum = "Istanbul" },
            new ProductItemBase { Id = 2, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "Penta Teknoloji", UrunCins = "Ekran Kartı", UrunAdet = 3243243, UrunAgirlik = 250 , DepoKonum = "Bursa" },
            new ProductItemBase { Id = 3, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "Vatan Computer", UrunCins = "Ekran Kartı", UrunAdet = 4829424, UrunAgirlik = 300 , DepoKonum = "İzmir" },
            new ProductItemBase { Id = 4, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "Teknosa", UrunCins = "Laptop", UrunAdet = 2935643, UrunAgirlik = 500 , DepoKonum = "Erzurum" },
            new ProductItemBase { Id = 5, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 250 , DepoKonum = "Malatya" },
            new ProductItemBase { Id = 6, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 250 , DepoKonum = "Malatya" },
            new ProductItemBase { Id = 7, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 250 , DepoKonum = "Malatya" },
        };

    }
}