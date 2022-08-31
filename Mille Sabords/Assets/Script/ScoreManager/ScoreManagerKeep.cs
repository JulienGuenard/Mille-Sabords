using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerKeep : ScoreManagerHeritage
{
    [HideInInspector] public int score = 0;
    List<int> P1_scoreList = new List<int>();
    List<int> P2_scoreList = new List<int>();

    List<int> playerScore = new List<int>();

    int playerScored = 1;

    public int GetPlayerScore(int playerNb) { return playerScore[playerNb]; }

    public new void Awake()
    {
        base.Awake();
        playerScore.Add(0);
        playerScore.Add(0);
    }

    public void KeepScore()
    {
        playerScored = GameManager.instance.gameM_Player.GetPlayerTurn();

        if (DiceManager.instance.diceM_Skulls.GetCorsairDices() != 0)
        {
            playerScored++;
            if (playerScored > 2) playerScored = 1;
        }

        switch (playerScored)
        {
            case 1:
                if (P1_scoreList.Count > 0) score += P1_scoreList[P1_scoreList.Count - 1];
                P1_scoreList.Add(score);
                playerScore[0] = score;
                break;
            case 2:
                if (P2_scoreList.Count > 0) score += P2_scoreList[P2_scoreList.Count - 1];
                P2_scoreList.Add(score);
                playerScore[1] = score;
                break;
        }

        string newTxt = " ";

        if (playerScored == 1)
        {
            for (int i = 0; i < P1_scoreList.Count; i++)
            {
                if (i == 0) UIManager.instance.uiM_Feedbacks.ChangePlayerScoreText(1, " ");
                newTxt = UIManager.instance.uiM_Feedbacks.P1_scoreText.text + P1_scoreList[i].ToString() + "\n";
                UIManager.instance.uiM_Feedbacks.ChangePlayerScoreText(1, newTxt);
            }
        }

        if (playerScored == 2)
        {
            for (int i = 0; i < P2_scoreList.Count; i++)
            {
                        if (i == 0) UIManager.instance.uiM_Feedbacks.ChangePlayerScoreText(2, " ");
                        newTxt = UIManager.instance.uiM_Feedbacks.P2_scoreText.text + P2_scoreList[i].ToString() + "\n";
                        UIManager.instance.uiM_Feedbacks.ChangePlayerScoreText(2, newTxt);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (scoreM_Keep.GetPlayerScore(i) >= 500)
            {
                UIManager.instance.uiM_Winner.Win(i);
            }
        }

        GameManager.instance.gameM_Player.NextPlayerTurn();
        ScoreManager.instance.ResetScore();
    }
}
