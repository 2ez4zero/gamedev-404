using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public Text dialogueText;
    public Button nextButton;
    public Button continueButton;

    [Header("Dialogue Lines")]
    [TextArea(2, 5)]
    public string[] dialogueLines;

    public float typingSpeed = 0.04f;

    [Header("Optional Behavior")]
    public bool showInventoryAfterDialogue = false; // ✅ Toggle this in Inspector

    private int currentLine = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        nextButton.onClick.AddListener(OnNextClicked);
        continueButton.onClick.AddListener(OnContinueClicked);

        // Initial button state
        nextButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);

        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in dialogueLines[currentLine])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

        // Last line? Hide next and show continue
        if (currentLine == dialogueLines.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(true);
        }
    }

    void OnNextClicked()
    {
        if (isTyping)
        {
            // Fast-forward current line
            StopCoroutine(typingCoroutine);
            dialogueText.text = dialogueLines[currentLine];
            isTyping = false;
        }
        else
        {
            currentLine++;

            if (currentLine < dialogueLines.Length)
            {
                typingCoroutine = StartCoroutine(TypeLine());
            }
            else
            {
                // 🔥 Last line just finished
                nextButton.gameObject.SetActive(false);
                continueButton.gameObject.SetActive(true);
            }
        }
    }

    void OnContinueClicked()
    {
        Debug.Log("Dialogue finished!");

        // ✅ Show inventory only if this dialogue should trigger it
        if (showInventoryAfterDialogue && InventoryManager.instance != null)
        {
            InventoryManager.instance.ShowInventory();
            Debug.Log("Inventory now shown.");
        }

        // 🔄 Optional: hide the dialogue UI
        gameObject.SetActive(false); // Or disable the panel that holds the dialogue
    }
}
