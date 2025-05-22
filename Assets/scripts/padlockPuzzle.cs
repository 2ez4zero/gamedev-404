using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PadlockPuzzle : MonoBehaviour
{
    public InputField input1, input2, input3; // Input fields for code
    public Text hintText; // Displays feedback
    public GameObject panelToHide; // The panel that will be hidden after success

    private string correctCode = "371"; // Your correct combination

    public void CheckCode()
    {
        string guess = input1.text + input2.text + input3.text;

        if (guess == correctCode)
        {
            hintText.text = "Unlocked!";
            Invoke("LoadShelfScene", 1.5f); // Delay to show success message
        }
        else
        {
            hintText.text = "Incorrect. Try again!";
        }
    }

    void LoadShelfScene()
    {
        SceneManager.LoadScene("shelfScene"); // Make sure your scene is added to Build Settings and named correctly!
    }

    public void ClosePanel()
    {
        panelToHide.SetActive(false);
    }
}
