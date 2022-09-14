using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void TwoPlayer_Game()
    {
        SceneManager.LoadScene("2P_Game");
    }
}
