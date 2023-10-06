using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EasyBarcodeMAU.Models {
    public class ProductModel : BaseViewModel {

        public List<ProductItemBase> MyItems { get; set; } = new List<ProductItemBase>
        {
            new ProductItemBase { Id = 1, DefterNo = 123321456, DepoGirisi = DateTime.Now, MusteriAd = "Beko", UrunCins = "KALEM", UrunAdet = 7839858, UrunAgirlik = 195 , DepoKonum = "Yakacık yeni mah veysel sokak no 9 daire 4 KARTAL / İSTANBUL Hanımeli sokak no 6 daire 4 Düzce / Kaynaşlı " },
            new ProductItemBase { Id = 2, DefterNo = 213213123, DepoGirisi = DateTime.Now, MusteriAd = "Penta Teknoloji", UrunCins = "Ekran Kartı", UrunAdet = 3243243, UrunAgirlik = 250 , DepoKonum = "Bursa" },
            new ProductItemBase { Id = 3, DefterNo = 453223323, DepoGirisi = DateTime.Now, MusteriAd = "Vatan Computer", UrunCins = "Ekran Kartı", UrunAdet = 4829424, UrunAgirlik = 300 , DepoKonum = "İzmir" },
            new ProductItemBase { Id = 4, DefterNo = 234142323, DepoGirisi = DateTime.Now, MusteriAd = "Teknosa", UrunCins = "Laptop", UrunAdet = 2935643, UrunAgirlik = 500 , DepoKonum = "Erzurum" },
            new ProductItemBase { Id = 5, DefterNo = 533532323, DepoGirisi = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = 3539531, UrunAgirlik = 210 , DepoKonum = "Antalya" },
            new ProductItemBase { Id = 6, DefterNo = 234322443, DepoGirisi = DateTime.Now, MusteriAd = "FarmTown", UrunCins = "Tahıl", UrunAdet = 3539531, UrunAgirlik = 650 , DepoKonum = "Kars" },
            new ProductItemBase { Id = 7, DefterNo = 234324324, DepoGirisi = DateTime.Now, MusteriAd = "PetCat", UrunCins = "Hayvan Maması", UrunAdet = 3539531, UrunAgirlik = 50 , DepoKonum = "Erzurum" },
        };
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
    }
}