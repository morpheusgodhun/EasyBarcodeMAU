using System.ComponentModel;

namespace EasyBarcodeMAU {
    public class ProductItemBase : INotifyPropertyChanged {
        public int Id { get; set; }
        public int DefterNo { get; set; }
        public DateTime DepoGirisi { get; set; }
        public string MusteriAd { get; set; }
        public string UrunCins { get; set; }
        public int UrunAdet { get; set; }
        public int UrunAgirlik { get; set; }
        public string DepoKonum { get; set; }
        public long BarkodNo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
