using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    [HideInInspector] public GameManagerPlayer gameM_Player;
    [HideInInspector] public GameManagerTurn gameM_Turn;
    [HideInInspector] public GameManagerPhase gameM_Phase;

    private void Awake()
    {
        if (instance == null) { instance = this; }

        gameM_Player = GetComponent<GameManagerPlayer>();
        gameM_Turn = GetComponent<GameManagerTurn>();
        gameM_Phase = GetComponent<GameManagerPhase>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { ResetGame(); }
    }

    void ResetGame()
    {
        SceneManager.LoadScene("main");
    }
}
