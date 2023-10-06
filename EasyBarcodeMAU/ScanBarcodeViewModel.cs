using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EasyBarcodeMAU.Models {
    public class ScanBarcodeViewModel : INotifyPropertyChanged {
        private string _barcodeValue;

        public string BarcodeValue {
            get { return _barcodeValue; }
            set {
                if (_barcodeValue != value) {
                    _barcodeValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
