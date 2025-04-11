using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToWalk : MonoBehaviour
{
    public void walk()
    {
        SceneManager.LoadScene("lakad");
    }

    public void likod()
    {
        SceneManager.LoadScene("talikod");
    }


}
