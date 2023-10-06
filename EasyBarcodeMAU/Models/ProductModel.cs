using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EasyBarcodeMAU.Models {
    public class ProductModel : BaseViewModel  {

        public List<ProductItemBase> MyItems { get; set; } = new List<ProductItemBase>
        {
            new ProductItemBase { Id = 1, DefterNo = 123321456, DepoGirisi = DateTime.Now, MusteriAd = "Beko", UrunCins = "KALEM", UrunAdet = 7839858, UrunAgirlik = 195 , DepoKonum = "Yakacık yeni mah veysel sokak no 9 daire 4 KARTAL / İSTANBUL Hanımeli sokak no 6 daire 4 Düzce / Kaynaşlı " },
            new ProductItemBase { Id = 2, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "Penta Teknoloji", UrunCins = "Ekran Kartı", UrunAdet = 3243243, UrunAgirlik = 250 , DepoKonum = "Bursa" },
            new ProductItemBase { Id = 3, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "Vatan Computer", UrunCins = "Ekran Kartı", UrunAdet = 4829424, UrunAgirlik = 300 , DepoKonum = "İzmir" },
            new ProductItemBase { Id = 4, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "Teknosa", UrunCins = "Laptop", UrunAdet = 2935643, UrunAgirlik = 500 , DepoKonum = "Erzurum" },
            new ProductItemBase { Id = 5, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 250 , DepoKonum = "ali" },
            new ProductItemBase { Id = 6, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 250 , DepoKonum = "Malatya" },
            new ProductItemBase { Id = 7, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 250 , DepoKonum = "Malatya" },
        };

    }
}

//public ProductModel()
//{
//    MyItems.Add(new ProductItemBase { Id = 1, DefterNo = 123321456, DepoGirisi = DateTime.Now, MusteriAd = "Beko", UrunCins = "KALEM", UrunAdet = 7839858, UrunAgirlik = 195 , DepoKonum = "Yakacık yeni mah veysel sokak no 9 daire 4 KARTAL / İSTANBUL Hanımeli sokak no 6 daire 4 Düzce / Kaynaşlı" });
//    MyItems.Add(new ProductItemBase { Id = 2, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "Penta Teknoloji", UrunCins = "Ekran Kartı", UrunAdet = 3243243, UrunAgirlik = 250, DepoKonum = "Sivas" });
//    MyItems.Add(new ProductItemBase { Id = 3, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "Vatan Computer", UrunCins = "Ekran Kartı", UrunAdet = 4829424, UrunAgirlik = 300, DepoKonum = "İzmir" });
//    MyItems.Add(new ProductItemBase { Id = 4, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "Teknosa", UrunCins = "Laptop", UrunAdet = 2935643, UrunAgirlik = 500, DepoKonum = "Erzurum" });
//    MyItems.Add(new ProductItemBase { Id = 5, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 250, DepoKonum = "ali" });
//    MyItems.Add(new ProductItemBase { Id = 6, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 250, DepoKonum = "Malatya" });
//    MyItems.Add(new ProductItemBase { Id = 7, DefterNo = 321321512, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 250, DepoKonum = "Malatya" });



//}

//private ObservableCollection<ProductItemBase> _myItems = new ObservableCollection<ProductItemBase>();

//public ObservableCollection<ProductItemBase> MyItems
//{
//    get { return _myItems; }
//    set
//    {
//        _myItems = value;
//        OnPropertyChanged(nameof(MyItems));
//    }
//}
