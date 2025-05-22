using UnityEngine;

public class CollectableItem : MonoBehaviour
{


    public Sprite itemIcon;           // Assign your sprite in Inspector
    public string uniqueName;         // e.g., "key_bedroom"

    private void Start()
    {
        // If already in inventory, disable it
        if (InventoryManager.instance != null && InventoryManager.instance.HasItem(uniqueName))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (InventoryManager.instance == null)
            return;

        if (InventoryManager.instance.HasItem(uniqueName))
            return;

        // Add to inventory with name
        InventoryManager.instance.AddItem(itemIcon, uniqueName);

        // Hide the object
        gameObject.SetActive(false);
    }
}
