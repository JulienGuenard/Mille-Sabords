using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI P1_scoreText;
    public TextMeshProUGUI P2_scoreText;

    static public ScoreManager instance;

    [HideInInspector] public ScoreManagerIncrement scoreM_Increment;
    [HideInInspector] public ScoreManagerKeep scoreM_Keep;

    private void Awake()
    {
        if (instance == null) { instance = this; }

        P1_scoreText.text = " ";
        P2_scoreText.text = " ";

        scoreM_Increment = GetComponent<ScoreManagerIncrement>();
        scoreM_Keep = GetComponent<ScoreManagerKeep>();
    }

    public void NewScore(List<DiceFace> resultDiceFaceList)
    {
        scoreM_Increment.NewScoreInit();
        scoreM_Increment.NewScoreCumulSkulls(DiceManager.instance.diceM_Skulls.GetCorsairDices());

        if (DiceManager.instance.diceM_Skulls.GetCorsairDices() == 0)
        {
            DiceManager.instance.SetIsFirstRoll(false);
            scoreM_Increment.NewScoreCumulFaces(resultDiceFaceList);

        }

        scoreM_Increment.NewScoreIncrement();
    }

    public void ResetScore()
    {
        scoreM_Keep.score = 0;
        WriteScore();
    }

    public void AddScore(int pt)
    {
        scoreM_Keep.score += pt;
        WriteScore();
    }

    public void SetScore(int pt)
    {
        scoreM_Keep.score = pt;
        WriteScore();
    }

    public void WriteScore()
    {
        scoreText.text = "score : " + scoreM_Keep.score;
    }
}
