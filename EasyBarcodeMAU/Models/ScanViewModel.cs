using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyBarcodeMAU.Models
{
    public class ScanViewModel:INotifyPropertyChanged
    {
 

        private ObservableCollection<ReadBaseModel> scannedBarcodes = new ObservableCollection<ReadBaseModel>();

        public ObservableCollection<ReadBaseModel> ScannedBarcodes
        {
            get => scannedBarcodes;
            set
            {
                scannedBarcodes = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
