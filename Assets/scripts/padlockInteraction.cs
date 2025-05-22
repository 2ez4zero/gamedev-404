using System.Collections.Generic;
using UnityEngine;

public class Padlock : MonoBehaviour
{
    public string requiredKeyName = "key_bedroom"; // Set this in Inspector to match your key's uniqueName
    public string padlockID = "padlock_bedroom";   // Unique identifier for this padlock

    private static HashSet<string> unlockedPadlocks = new HashSet<string>(); // Session tracking

    private void Start()
    {
        // If this padlock has already been unlocked in this session, hide it
        if (unlockedPadlocks.Contains(padlockID))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (InventoryManager.instance == null)
            return;

        if (InventoryManager.instance.HasItem(requiredKeyName))
        {
            Debug.Log("Padlock unlocked!");

            // Track and disable this padlock
            unlockedPadlocks.Add(padlockID);
            gameObject.SetActive(false);
        }
        else
        {
            // Show popup: key needed
            Debug.Log("You need a key to open this padlock.");
            // Optional: Add a UI popup message here
        }
    }
}
