using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU {
    public class ProductModel : BaseViewModel {
        public ProductModel() {
            Id = 1;
        }

        public List<ProductItemBase> MyItems { get; set; } = new List<ProductItemBase>
        {
            new ProductItemBase { Id = 1, DefterNo = 123321456, DepoGirisi = DateTime.Now, MusteriAd = "Beko", UrunCins = "KALEM", UrunAdet = 7839858, UrunAgirlik = 195 , DepoKonum = "Istanbul" },
           
            //new ProductItemBase { Id = 3, DefterNo = 23, DepoGirisTarih = DateTime.Now, MusteriAd = "Vatan Computer", UrunCins = "Ekran Kartı", UrunAdet = "4829424", UrunAgirlik = 300 , DepoKonum = "İzmir" },
            //new ProductItemBase { Id = 4, DefterNo = 23, DepoGirisTarih = DateTime.Now, MusteriAd = "Teknosa", UrunCins = "Laptop", UrunAdet = "2935643", UrunAgirlik = 500 , DepoKonum = "Erzurum" },
            //new ProductItemBase { Id = 5, DefterNo = 23, DepoGirisTarih = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = "3539531", UrunAgirlik = 250 , DepoKonum = "Malatya" }
        };

        public List<ProductItemBase> GetItemsById(int id) {
            return MyItems.Where(item => item.Id == id).ToList();
        }

        private int _id;
        public int Id {
            get { return _id; }
            set {
                if (_id != value) {
                    _id = value;
                }
            }
        }
        private int _defterNo;
        public int DefterNo {
            get { return _defterNo; }
            set {
                if (_defterNo != value) {
                    _defterNo = value;
                 
                }
            }
        }

        private DateTime _depoGirisi;
        public DateTime DepoGirisi {
            get { return _depoGirisi; }
            set {
                if (_depoGirisi != value) {
                    _depoGirisi = value;
                }
            }
        }

        private string _musteriAd;
        public string MusteriAd {
            get { return _musteriAd; }
            set {
                if (_musteriAd != value) {
                    _musteriAd = value;
                    
                }
            }
        }
        private string _urunCins;
        public string UrunCins {
            get { return _urunCins; }
            set {
                if (_urunCins != value) {
                    _urunCins = value;
                   
                }
            }
        }
        private int _urunAdet;
        public int UrunAdet {
            get { return _urunAdet; }
            set {
                if (_urunAdet != value) {
                    _urunAdet = value;
                   
                }
            }
        }
        private int _urunAgirlik;
        public int UrunAgirlik {
            get { return _urunAgirlik; }
            set {
                if (_urunAgirlik != value) {
                    _urunAgirlik = value;
                   
                }
            }
        }
        private string _depoKonum;
        public string DepoKonum {
            get { return _depoKonum; }
            set {
                if (_depoKonum != value) {
                    _depoKonum = value;
                 
                }
            }
        }
        private long _barkodNo;
        public long BarkodNo {
            get { return _barkodNo; }
            set {
                if (_barkodNo != value) {
                    _barkodNo = value;
                
                }
            }
        }
    }
}
