using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    

    [Header("Inventory UI")]
    public GameObject inventoryPanel;           // The UI panel for inventory
    public InventorySlot[] slots;               // Array of inventory slots

    private HashSet<string> collectedItemNames = new HashSet<string>(); // Track item names

    void Awake()
    {
        // Singleton setup to persist between scenes
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        // Optional: hide inventory at game start
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void ShowInventory()
    {
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(true);
        }
    }

    public void HideInventory()
    {
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    // ✅ Updated to accept item name
    public void AddItem(Sprite itemIcon, string itemName)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(itemIcon);
                collectedItemNames.Add(itemName); // Track item
                Debug.Log("Item added to inventory: " + itemName);
                return;
            }
        }

        Debug.LogWarning("Inventory full!");
    }

    // ✅ Public check for item by name
    public bool HasItem(string itemName)
    {
        return collectedItemNames.Contains(itemName);
    }
}
