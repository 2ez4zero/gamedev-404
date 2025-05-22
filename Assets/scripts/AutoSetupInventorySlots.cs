using UnityEngine;
using UnityEngine.UI;

public class AutoSetupInventorySlots : MonoBehaviour
{
    [Tooltip("Assign your Inventory Container (parent of slots) here")]
    public Transform inventoryContainer;

    void Start()
    {
        if (inventoryContainer == null)
        {
            Debug.LogError("Inventory Container not assigned!");
            return;
        }

        foreach (Transform slot in inventoryContainer)
        {
            // Add InventorySlot script if missing
            InventorySlot invSlot = slot.GetComponent<InventorySlot>();
            if (invSlot == null)
            {
                invSlot = slot.gameObject.AddComponent<InventorySlot>();
                Debug.Log($"Added InventorySlot to {slot.name}");
            }

            // Find child Image component (assumed to be the icon)
            Image iconImage = slot.GetComponentInChildren<Image>();
            if (iconImage == null)
            {
                Debug.LogWarning($"No Image component found in children of {slot.name}");
                continue;
            }

            // Assign the icon image to the InventorySlot script
            invSlot.icon = iconImage;

            // Clear and disable icon
            iconImage.sprite = null;
            iconImage.enabled = false;
        }

        Debug.Log("Inventory slots auto-setup complete.");
    }
}
