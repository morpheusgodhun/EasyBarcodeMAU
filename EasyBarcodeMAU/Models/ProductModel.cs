namespace EasyBarcodeMAU.Models;
public class ProductModel : BaseViewModel {

    #region List
    public List<ProductItemBase> ProductItems { get; set; } = new List<ProductItemBase>
    {
            new ProductItemBase { Id = 1, DefterNo = 123321456, DepoGirisi = DateTime.Now, MusteriAd = "Beko", UrunCins = "Mobilya", UrunAdet = 7839858, UrunAgirlik = 195 , DepoKonum = "Yakacık Yeni Mah Veysel Sokak NO:9, Kartal/İstanbul", RequiredCount=5 },
            new ProductItemBase { Id = 2, DefterNo = 213213123, DepoGirisi = DateTime.Now, MusteriAd = "Penta Teknoloji", UrunCins = "Ekran Kartı", UrunAdet = 3243243, UrunAgirlik = 250 , DepoKonum = "Kaynarca Mahallesi Sağduyu Sokak 2/A, Bursa/Merkez",RequiredCount=10},
            new ProductItemBase { Id = 3, DefterNo = 453223323, DepoGirisi = DateTime.Now, MusteriAd = "Vatan Computer", UrunCins = "MousePad", UrunAdet = 4829424, UrunAgirlik = 300 , DepoKonum = "Gazi Blv. No:97, İzmir/Merkez", RequiredCount=20},
            new ProductItemBase { Id = 4, DefterNo = 234142323, DepoGirisi = DateTime.Now, MusteriAd = "Teknosa", UrunCins = "Laptop", UrunAdet = 2935643, UrunAgirlik = 500 , DepoKonum = "Solakzade Mah. Yavuz Sultan Selim Bulvarı Erzurum Alışveriş Merkezi No:43, Erzurum/Merkez" , RequiredCount=30 },
            new ProductItemBase { Id = 5, DefterNo = 533532323, DepoGirisi = DateTime.Now, MusteriAd = "Armut Kırtasiye", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 210 , DepoKonum = "Saray Mh. İsmet Hilmi Balcı Cd.Damlataş Eğlence Merkezi Önü, Antalya/Merkez" , RequiredCount=40},
            new ProductItemBase { Id = 6, DefterNo = 234322443, DepoGirisi = DateTime.Now, MusteriAd = "FarmTown", UrunCins = "Tahıl", UrunAdet = 3539531, UrunAgirlik = 650 , DepoKonum = "Karlıktepe Mah., Ak Sokak, No:4 Kars/Merkez" , RequiredCount=50 },
            new ProductItemBase { Id = 7, DefterNo = 234324324, DepoGirisi = DateTime.Now, MusteriAd = "PetCat", UrunCins = "Hayvan Maması", UrunAdet = 3539531, UrunAgirlik = 50 , DepoKonum = "Yukarı Mumcu Çaykara Caddesi No:20 Erzurum/Oltu " , RequiredCount=60}
        };

    #endregion

    #region Properties

    private int _count;
    public int Count {
        get { return _count; }
        set {

            if (_count != value) {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
    }






    private string selectedProduct;
    public string SelectedProduct {
        get { return selectedProduct; }
        set {
            if (selectedProduct != value) {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));

            }
        }
    }

    #endregion

}