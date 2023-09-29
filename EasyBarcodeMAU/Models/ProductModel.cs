using EasyBarcodeMAU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EasyBarcodeMAU {
    public class ProductModel : BaseViewModel {
        public ProductModel() {
            FirmaId = 1; // Varsayılan seçim 1
        }

        public List<ProductItemBase> MyItems { get; set; } = new List<ProductItemBase>
        {
            new ProductItemBase { Id = 1, DefterNo = 123321456, DepoGirisTarih = DateTime.Now, MusteriAd = "Beko", UrunCins = "KALEM", UrunAdet = "7839858", UrunAgirlik = 195 , DepoKonum = "Istanbul" },
            new ProductItemBase { Id = 2, DefterNo = 321321512, DepoGirisTarih = DateTime.Now, MusteriAd = "Penta Teknoloji", UrunCins = "Ekran Kartı", UrunAdet = "3243243", UrunAgirlik = 250 , DepoKonum = "Bursa" },
            new ProductItemBase { Id = 3, DefterNo = 23, DepoGirisTarih = DateTime.Now, MusteriAd = "Vatan Computer", UrunCins = "Ekran Kartı", UrunAdet = "4829424", UrunAgirlik = 300 , DepoKonum = "İzmir" },
            new ProductItemBase { Id = 4, DefterNo = 23, DepoGirisTarih = DateTime.Now, MusteriAd = "Teknosa", UrunCins = "Laptop", UrunAdet = "2935643", UrunAgirlik = 500 , DepoKonum = "Erzurum" },
            new ProductItemBase { Id = 5, DefterNo = 23, DepoGirisTarih = DateTime.Now, MusteriAd = "ARMUT", UrunCins = "Kitap", UrunAdet = "3539531", UrunAgirlik = 250 , DepoKonum = "Malatya" }
        };

        public List<ProductItemBase> GetItemsById(int id) {
            // Id'ye göre filtrele
            return MyItems.Where(item => item.Id == id).ToList();
        }

        private int _id;
        public int Id {
            get { return _id; }
            set {
                if (_id != value) {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
    }
}
