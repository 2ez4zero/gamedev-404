using UnityEngine;

public class ClickablePuzzleTrigger : MonoBehaviour
{
    public GameObject puzzlePanel;

    private void OnMouseDown()
    {
        puzzlePanel.SetActive(true);
        Debug.Log("Padlock clicked");
        puzzlePanel.SetActive(true);
        if (puzzlePanel != null)
        {
            puzzlePanel.SetActive(true);
            Debug.Log("Puzzle panel set active");
        }
        else
        {
            Debug.LogWarning("Puzzle panel is not assigned!");
        }
    }
}
