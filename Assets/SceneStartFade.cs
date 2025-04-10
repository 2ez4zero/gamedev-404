using UnityEngine;

public class SceneStartFade : MonoBehaviour
{
    public Animator fadeAnimator;

    void Start()
    {
        fadeAnimator.Play("FadeIn");
    }
}
