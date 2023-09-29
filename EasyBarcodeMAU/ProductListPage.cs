namespace EasyBarcodeMAU;

public class ProductListPage : ContentPage
{
	public ProductListPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Orhun Test"
				}
			}
		};
	}
}