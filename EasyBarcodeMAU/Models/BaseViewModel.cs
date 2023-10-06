using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EasyBarcodeMAU.Models;
    public class BaseViewModel : INotifyPropertyChanged {
        #region Variables
        private string title = string.Empty;
        #endregion

        #region Properties

        public string Description {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        #endregion

        #region Methods
        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName] string propertyName = "",
           Action onChanged = null) {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            var changed = PropertyChanged;
            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
