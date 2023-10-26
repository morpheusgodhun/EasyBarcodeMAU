namespace EasyBarcodeMAU.Models;
public class ProductItemManager {

    public event Action<ProductItemBase> OnDeleteSelectedItem;
    public event Action<ProductItemBase> OnUpdateSelectedItem;

    public void DeleteSelectedItem(ProductItemBase selectedItem) {
        OnDeleteSelectedItem?.Invoke(selectedItem);
    }
    public void UpdateSelectedItem(ProductItemBase _onUpdateSelect) {
        OnUpdateSelectedItem?.Invoke(_onUpdateSelect);
    }
}