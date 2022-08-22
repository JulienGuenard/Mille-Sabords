using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI P1_scoreText;
    public TextMeshProUGUI P2_scoreText;

    List<int> P1_scoreList = new List<int>();
    List<int> P2_scoreList = new List<int>();

    static public ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        P1_scoreText.text = " ";
        P2_scoreText.text = " ";
    }

    public void NewScore(List<DiceFace> resultDiceFaceList)
    {
        List<int> comboList = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            comboList.Add(0);
        }

        int chestcombo = 0;

        foreach (DiceFace d in resultDiceFaceList)
        {
            switch (d)
            {
                case DiceFace.Coin:
                    AddScore(100);
                    comboList[0]++;
                    chestcombo++;
                    break;
                case DiceFace.Diamond:
                    AddScore(100);
                    comboList[1]++;
                    chestcombo++;
                    break;
                case DiceFace.Swords:
                    comboList[2]++;
                    break;
                case DiceFace.Perroquet:
                    comboList[3]++;
                    break;
                case DiceFace.Monkey:
                    comboList[4]++;
                    break;
            }
        }

        for(int i = 0; i < 5; i++)
        {
                switch (comboList[i])
                {
                    case 3: AddScore(100); break;
                    case 4: AddScore(200); break;
                    case 5: AddScore(500); break;
                    case 6: AddScore(1000); break;
                    case 7: AddScore(2000); break;
                    case 8: AddScore(4000); break;
                }

            if (i >= 2)
            {
                if (comboList[i] >= 3) chestcombo += comboList[i];
            }
        }

        if (chestcombo == 8) AddScore(500);
    }

   public void KeepScore()
    {
            switch (GameManager.instance.GetPlayerTurn())
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
                switch (GameManager.instance.GetPlayerTurn())
                {
                    case 1:
                        if (i == 0) P1_scoreText.text = " ";
                        P1_scoreText.text += P1_scoreList[i].ToString() + "\n";
                        break;
                    case 2:
                        if (i == 0) P2_scoreText.text = " ";
                        P2_scoreText.text += P2_scoreList[i].ToString() + "\n";
                        break;
                }
            }


        GameManager.instance.NextPlayerTurn();
        ResetScore();
    }

    public void AddScore(int pt)
    {
        score += pt;
        WriteScore();
    }

    public void ResetScore()
    {
        score = 0;
        WriteScore();
    }

    void WriteScore()
    {
        scoreText.text = "score : " + score;

    }
}
