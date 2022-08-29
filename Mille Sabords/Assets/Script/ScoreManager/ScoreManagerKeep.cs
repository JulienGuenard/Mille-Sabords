using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerKeep : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    List<int> P1_scoreList = new List<int>();
    List<int> P2_scoreList = new List<int>();

    public void KeepScore()
    {
        switch (GameManager.instance.gameM_Player.GetPlayerTurn())
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

        for (int i = 0; i < P1_scoreList.Count; i++)
        {
            switch (GameManager.instance.gameM_Player.GetPlayerTurn())
            {
                case 1:
                    if (i == 0) ScoreManager.instance.P1_scoreText.text = " ";
                    ScoreManager.instance.P1_scoreText.text += P1_scoreList[i].ToString() + "\n";
                    break;
                case 2:
                    if (i == 0) ScoreManager.instance.P2_scoreText.text = " ";
                    ScoreManager.instance.P2_scoreText.text += P2_scoreList[i].ToString() + "\n";
                    break;
            }
        }

        GameManager.instance.gameM_Player.NextPlayerTurn();
        ScoreManager.instance.ResetScore();
    }
}
