using ZXing.Net.Maui.Controls;
namespace EasyBarcodeMAU;

public partial class ScanBarcodeScreen : ContentPage {
    public ScanBarcodeScreen() {
        InitializeComponent();
        barCodereader.Options = new ZXing.Net.Maui.BarcodeReaderOptions {
            Formats = ZXing.Net.Maui.BarcodeFormat.Ean13
        };
    }
    public long BarcodeValue { get; set; }

    private void barCodereader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e) {
        barCodereader.IsDetecting = false;
        if (e.Results.Any()) {
            var result = e.Results.FirstOrDefault();
            Dispatcher.Dispatch(async () => {
                var navigationParam = new Dictionary<string, object>() {
                    {"qrCodeResult" , result.Value }
                };
                await Shell.Current.GoToAsync("..", navigationParam);
            });
        }
    }
}