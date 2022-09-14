using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GameManagerHeritage
{
    static public GameManager instance;

    private new void Awake()
    {
        base.Awake();
        if (instance == null) { instance = this; }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { ResetGame(); }
    }

    void ResetGame()
    {
        SceneManager.LoadScene("2P_Game");
    }
}
