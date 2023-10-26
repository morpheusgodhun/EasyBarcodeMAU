namespace EasyBarcodeMAU.Models;
    public class ProductItemManager {
        public event Action<ProductItemBase> OnDeleteSelectedItem;

        public void DeleteSelectedItem(ProductItemBase selectedItem) {
            OnDeleteSelectedItem?.Invoke(selectedItem);
        }
    }