using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU {
    public partial class ProductListPage : ContentPage {

        public ProductListPage() {
            InitializeComponent();
            viewModel = new ProductModel();
            BindingContext = viewModel;
        }
        ProductModel viewModel;

        private async void Frame_Tapped(object sender, EventArgs e) {
            if (sender is Frame tappedFrame) {
                if (tappedFrame.Content is StackLayout stackLayout) {
                    if (stackLayout.Children[0] is Grid grid) {
                        List<string> labelContents = new List<string>();

                        foreach (var child in grid.Children) {
                            if (child is Grid childGrid) {
                                foreach (var labelChild in childGrid.Children) {
                                    if (labelChild is Label label) {
                                        string labelText = label.Text;
                                        labelContents.Add(labelText);
                                    }
                                }
                            }
                        }

                        // Düzenleme: labelContents listesini düzenle
                        List<string> modifiedContents = new List<string>();
                        for (int i = 0; i < labelContents.Count / 2; i++) {
                            modifiedContents.Add($"{labelContents[i]} {labelContents[i + labelContents.Count / 2]}");
                        }

                        string message = string.Join("\n", modifiedContents);
                        await DisplayAlert("Ürün Detayý", message, "Tamam");
                    }
                    await Navigation.PushModalAsync(new ScanBarcodeScreen());
                }
            }
        }

        private void OnConfirmButtonClicked(object sender, EventArgs e) {
            var scanPage = new ScanBarcodeScreen();
            Navigation.PushAsync(scanPage);
        }
    }
}
