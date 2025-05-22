using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    // Check if the slot is empty based on whether icon is null or disabled
    public bool IsEmpty()
    {
        return icon.sprite == null || !icon.enabled;
    }

    public void SetItem(Sprite newIcon)
    {
        icon.sprite = newIcon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}
