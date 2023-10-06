using ZXing;
using Camera.MAUI.ZXingHelper;
namespace EasyBarcodeMAU;


public partial class ScanBarcodeScreen : ContentPage
{
    public ScanBarcodeScreen()
    {
        InitializeComponent();
       
    }

    private void cameraView_BarcodeDetected(object sender, BarcodeEventArgs args)
{
    MainThread.BeginInvokeOnMainThread(() =>
    {
        if (args.Result.Length > 0)
        {
            var format = args.Result[0].BarcodeFormat;
            var text = args.Result[0].Text;
            barcodeResult.Text = $"{format}: {text}";
        }
        else
        {
            barcodeResult.Text = "Barkod bulunamadư.";
        }
    });
}


    private void cameraView_CamerasLoaded (object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0) 
        { 
           cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }

    }

   
}



//barCodereader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
//{
//    Formats = ZXing.Net.Maui.BarcodeFormat.Ean13 | ZXing.Net.Maui.BarcodeFormat.Ean8
//    | ZXing.Net.Maui.BarcodeFormat.DataMatrix | ZXing.Net.Maui.BarcodeFormat.Aztec | ZXing.Net.Maui.BarcodeFormat.Codabar
//    | ZXing.Net.Maui.BarcodeFormat.Code39 | ZXing.Net.Maui.BarcodeFormat.Code93 | ZXing.Net.Maui.BarcodeFormat.Imb
//    | ZXing.Net.Maui.BarcodeFormat.Itf | ZXing.Net.Maui.BarcodeFormat.MaxiCode | ZXing.Net.Maui.BarcodeFormat.Msi
//    | ZXing.Net.Maui.BarcodeFormat.PharmaCode | ZXing.Net.Maui.BarcodeFormat.Plessey | ZXing.Net.Maui.BarcodeFormat.QrCode
//    | ZXing.Net.Maui.BarcodeFormat.Rss14 | ZXing.Net.Maui.BarcodeFormat.RssExpanded | ZXing.Net.Maui.BarcodeFormat.UpcA
//    | ZXing.Net.Maui.BarcodeFormat.UpcE | ZXing.Net.Maui.BarcodeFormat.UpcEanExtension
//};


//barCodereader.IsDetecting = false;
//if (e.Results.Any())
//{
//    var result = e.Results.FirstOrDefault();
//    Dispatcher.Dispatch(async () => {
//        var navigationParam = new Dictionary<string, object>() {
//            {"qrCodeResult" , result.Value }
//        };
//        await Shell.Current.GoToAsync("..", navigationParam);
//    });
//}




//namespace EasyBarcodeMAU;

//public partial class ScanBarcodeScreen : ContentPage {
//    public ScanBarcodeScreen() {
//        InitializeComponent();
//        barCodereader.Options = new ZXing.Net.Maui.BarcodeReaderOptions {
//            Formats = ZXing.Net.Maui.BarcodeFormat.Ean13 | ZXing.Net.Maui.BarcodeFormat.Ean8
//            | ZXing.Net.Maui.BarcodeFormat.DataMatrix | ZXing.Net.Maui.BarcodeFormat.Aztec | ZXing.Net.Maui.BarcodeFormat.Codabar
//            | ZXing.Net.Maui.BarcodeFormat.Code39 | ZXing.Net.Maui.BarcodeFormat.Code93 | ZXing.Net.Maui.BarcodeFormat.Imb
//            | ZXing.Net.Maui.BarcodeFormat.Itf | ZXing.Net.Maui.BarcodeFormat.MaxiCode | ZXing.Net.Maui.BarcodeFormat.Msi
//            | ZXing.Net.Maui.BarcodeFormat.PharmaCode | ZXing.Net.Maui.BarcodeFormat.Plessey | ZXing.Net.Maui.BarcodeFormat.QrCode
//            | ZXing.Net.Maui.BarcodeFormat.Rss14 | ZXing.Net.Maui.BarcodeFormat.RssExpanded | ZXing.Net.Maui.BarcodeFormat.UpcA
//            | ZXing.Net.Maui.BarcodeFormat.UpcE | ZXing.Net.Maui.BarcodeFormat.UpcEanExtension
//        };
//    }
//    public long BarcodeValue { get; set; }

//    private void barCodereader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e) {
//        barCodereader.IsDetecting = false;
//        if (e.Results.Any()) {
//            var result = e.Results.FirstOrDefault();
//            var barcodeValue = result.Value;
//            barcodeValueLabel2.BindingContext = barcodeValue;
//            Dispatcher.Dispatch(async () => {
//                var navigationParam = new Dictionary<string, object>() {
//                    {"qrCodeResult" , result.Value }
//                };
//                await Shell.Current.GoToAsync("..", navigationParam);
//            });
//        }
//    }
//}