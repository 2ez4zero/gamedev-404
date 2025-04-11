using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStartGame : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("startGame");
    }
}
