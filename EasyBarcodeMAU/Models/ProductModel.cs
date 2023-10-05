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

//private int _id;
//public int Id {
//    get { return _id; }
//    set {
//        if (_id != value) {
//            _id = value;
//            OnPropertyChanged(nameof(Id));
//            UpdateOtherFields();
//        }
//    }
//}
//private int _defterNo;
//public int DefterNo {
//    get { return _defterNo; }
//    set {
//        if (_defterNo != value) {
//            _defterNo = value;
//            OnPropertyChanged(nameof(DefterNo));

//        }
//    }
//}

//private DateTime _depoGirisi;
//public DateTime DepoGirisi {
//    get { return _depoGirisi; }
//    set {
//        if (_depoGirisi != value) {
//            _depoGirisi = value;
//            OnPropertyChanged(nameof(DepoGirisi));

//        }
//    }
//}

//private string _musteriAd;
//public string MusteriAd {
//    get { return _musteriAd; }
//    set {
//        if (_musteriAd != value) {
//            _musteriAd = value;
//            OnPropertyChanged(nameof(MusteriAd));

//        }
//    }
//}
//private string _urunCins;
//public string UrunCins {
//    get { return _urunCins; }
//    set {
//        if (_urunCins != value) {
//            _urunCins = value;
//            OnPropertyChanged(nameof(UrunCins));

//        }
//    }
//}
//private int _urunAdet;
//public int UrunAdet {
//    get { return _urunAdet; }
//    set {
//        if (_urunAdet != value) {
//            _urunAdet = value;
//            OnPropertyChanged(nameof(UrunAdet));

//        }
//    }
//}
//private int _urunAgirlik;
//public int UrunAgirlik {
//    get { return _urunAgirlik; }
//    set {
//        if (_urunAgirlik != value) {
//            _urunAgirlik = value;
//            OnPropertyChanged(nameof(UrunAgirlik));

//        }
//    }
//}
//private string _depoKonum;
//public string DepoKonum {
//    get { return _depoKonum; }
//    set {
//        if (_depoKonum != value) {
//            _depoKonum = value;
//            OnPropertyChanged(nameof(DepoKonum));

//        }
//    }
//}
//private long _barkodNo;
//public long BarkodNo {
//    get { return _barkodNo; }
//    set {
//        if (_barkodNo != value) {
//            _barkodNo = value;
//            OnPropertyChanged(nameof(BarkodNo));

//        }
//    }
//}

//public void UpdateOtherFields()
//{
//    if (Id == 1)
//    {
//        DefterNo = 222;
//        DepoGirisi = DateTime.Now;
//        MusteriAd = "Orhun";
//        UrunCins = "Kalem";
//        UrunAdet = 234123;
//        UrunAgirlik = 1233456;
//        DepoKonum = "Pendik";
//        BarkodNo = 32313213;

//    }
//    if (Id == 2)
//    {
//        DefterNo = 123112;
//        DepoGirisi = DateTime.Now;
//        MusteriAd = "Yusuf";
//        UrunCins = "Kalem";
//        UrunAdet = 234123;
//        UrunAgirlik = 1233456;
//        DepoKonum = "Pendik";
//        BarkodNo = 32313213;

//    }
//    if (Id == 3)
//    {
//        DefterNo = 123112;
//        DepoGirisi = DateTime.Now;
//        MusteriAd = "Ali";
//        UrunCins = "Kalem";
//        UrunAdet = 234123;
//        UrunAgirlik = 1233456;
//        DepoKonum = "Pendik";
//        BarkodNo = 32313213;

//    }
//    if (Id == 4)
//    {
//        DefterNo = 123112;
//        DepoGirisi = DateTime.Now;
//        MusteriAd = "Test";
//        UrunCins = "Kalem";
//        UrunAdet = 234123;
//        UrunAgirlik = 1233456;
//        DepoKonum = "Pendik";
//        BarkodNo = 32313213;

//    }
//    if (Id == 5)
//    {
//        DefterNo = 123;
//        DepoGirisi = DateTime.Now;
//        MusteriAd = "Nail";
//        UrunCins = "Kalem";
//        UrunAdet = 234123;
//        UrunAgirlik = 1233456;
//        DepoKonum = "Pendik";
//        BarkodNo = 32313213;

//    }
//    if (Id == 6)
//    {
//        DefterNo = 232;
//        DepoGirisi = DateTime.Now;
//        MusteriAd = "Yılmaz";
//        UrunCins = "Kalem";
//        UrunAdet = 234123;
//        UrunAgirlik = 1233456;
//        DepoKonum = "Pendik";
//        BarkodNo = 32313213;
//    }
//    if (Id == 7)
//    {
//        DefterNo = 111;
//        DepoGirisi = DateTime.Now;
//        MusteriAd = "Sdsa";
//        UrunCins = "Sasaa";
//        UrunAdet = 234123;
//        UrunAgirlik = 1233456;
//        DepoKonum = "Kartal";
//        BarkodNo = 32313213;
//    }
//}