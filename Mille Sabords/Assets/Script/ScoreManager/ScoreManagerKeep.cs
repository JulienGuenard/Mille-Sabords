using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerKeep : ScoreManagerHeritage
{
    [HideInInspector] public int score = 0;
    List<int> P1_scoreList = new List<int>();
    List<int> P2_scoreList = new List<int>();

    int playerScored = 1;

    public void KeepScore()
    {
        playerScored = GameManager.instance.gameM_Player.GetPlayerTurn();

        if (DiceManager.instance.diceM_Skulls.GetCorsairDices() != 0)
        {
            playerScored++;
            if (playerScored > 2) playerScored = 1;
        }

        Debug.Log(playerScored);

        switch (playerScored)
        {
            case 1:
                if (P1_scoreList.Count > 0) score += P1_scoreList[P1_scoreList.Count - 1];
                P1_scoreList.Add(score);
                break;
            case 2:
                if (P2_scoreList.Count > 0) score += P2_scoreList[P2_scoreList.Count - 1];
                P2_scoreList.Add(score);
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

        GameManager.instance.gameM_Player.NextPlayerTurn();
        ScoreManager.instance.ResetScore();
    }
}
