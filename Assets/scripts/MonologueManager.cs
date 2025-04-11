using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MonologueManager : MonoBehaviour
{
    [Header("UI Reference")]
    public Text monologueText;  // Drag your Text UI here in Inspector

    [Header("Monologue Settings")]
    [TextArea(2, 5)]
    public string monologue = "Default monologue here.";
    public float typingSpeed = 0.05f;

    private void Start()
    {
        if (monologueText == null)
        {
            Debug.LogError("Monologue Text is not assigned in the Inspector!", this);
            return;
        }

        StartCoroutine(DisplayMonologue());
    }

    IEnumerator DisplayMonologue()
    {
        monologueText.text = "";

        foreach (char letter in monologue)
        {
            monologueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Optional: wait for input before continuing
        // yield return new WaitUntil(() => Input.anyKeyDown);
        // Do something here (like transition or unfreeze player)
    }
}
