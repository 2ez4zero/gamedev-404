using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    public Animator fadeAnimator;
    public float fadeDuration = 1.0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Only for fade-out logic
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // No fade-in logic needed here anymore

    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(sceneName);
        // Do NOT trigger fade in — it’s handled in the new scene itself
    }
}
