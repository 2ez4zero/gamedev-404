using UnityEngine;

public class InventoryUIPersistence : MonoBehaviour
{
    private static InventoryUIPersistence instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ✅ Keeps this UI object alive across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates
        }
    }
}
