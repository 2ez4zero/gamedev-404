using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionTime = 1f; // Match this to your animation length
    public string nextSceneName = "startGame"; // Make sure this matches your scene name

    void Start()
    {
        // Play fade-in animation when the scene loads
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("start");
            Debug.Log("Fade-in animation triggered.");
        }
    }

    public void OnStartGameClicked()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log("Starting scene transition...");
            if (transitionAnimator != null)
            {
                StartCoroutine(LoadSceneWithFade(nextSceneName));
            }
            else
            {
                // Fallback: no animation
                SceneManager.LoadScene(nextSceneName);
            }
        }
        else
        {
            Debug.LogError("Next scene name is empty! Please assign it in the Inspector.");
        }
    }

    public IEnumerator LoadSceneWithFade(string sceneName)
    {
        Debug.Log("Fade-out animation triggered.");
        // Play fade-out animation
        transitionAnimator.SetTrigger("end");

        // Wait for the animation to finish
        yield return new WaitForSeconds(transitionTime);

        Debug.Log($"Loading scene: {sceneName}");
        // Load the scene
        SceneManager.LoadScene(sceneName);
    }
}
