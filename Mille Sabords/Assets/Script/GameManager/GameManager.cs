using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    int playerTurn = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    void ResetGame()
    {
        SceneManager.LoadScene("main");
    }

    public int GetPlayerTurn()
    {
        return playerTurn;
    }

    public void NextPlayerTurn()
    {
        playerTurn++;
        if (playerTurn >= 3) playerTurn = 1;

        UIManager.instance.ChangePlayerTurnText(playerTurn);
    }

    public void BeginPhase()
    {
        UIManager.instance.BeginPhase_ActiveUI();
        ScoreManager.instance.ResetScore();
    }

    public void EndPhase()
    {
        UIManager.instance.EndPhase_DesactiveUI();

        if (DiceManager.instance.GetResultDiceFaceList() == null) return;

        ScoreManager.instance.NewScore(DiceManager.instance.GetResultDiceFaceList());
    }

    public void RoundOver()
    {
        UIManager.instance.DisableRoll();
    }
}
