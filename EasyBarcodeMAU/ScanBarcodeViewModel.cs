using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EasyBarcodeMAU.Models;
public class ScanBarcodeViewModel : INotifyPropertyChanged {

    #region Variables

    private string _barcodeValue;
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Properties
    public string BarcodeValue {
        get { return _barcodeValue; }
        set {
            if (_barcodeValue != value) {
                _barcodeValue = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion

    #region Methods

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
