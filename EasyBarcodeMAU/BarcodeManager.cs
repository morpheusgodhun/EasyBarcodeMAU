using EasyBarcodeMAU.Models;
using System.Collections.ObjectModel;

namespace EasyBarcodeMAU;
public class BarcodeManager : ContentPage {
    private static BarcodeManager _instance;
    public static BarcodeManager Instance => _instance ??= new BarcodeManager();
    public ObservableCollection<ReadBaseModel> GlobalScannedBarcodes { get; private set; } = new ObservableCollection<ReadBaseModel>();
    private BarcodeManager() { }

    public void AddBarcode(ReadBaseModel barcode) {
        var existingBarcode = GlobalScannedBarcodes.FirstOrDefault(b => b.Barcode == barcode.Barcode);
        if (existingBarcode == null) {
            GlobalScannedBarcodes.Add(barcode);
        }
        else {
            existingBarcode.Count += barcode.Count;
        }
    }

    public bool IsBarcodeExist(string barcodeText) {
        return GlobalScannedBarcodes.Any(b => b.Barcode == barcodeText);
    }
}