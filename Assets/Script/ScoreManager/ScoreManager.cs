using System.Collections.Generic;
using TMPro;

public class ScoreManager : ScoreManagerHeritage
{
    public TextMeshProUGUI scoreText;

    static public ScoreManager instance;

    new void Awake()
    {
        base.Awake();
        if (instance == null) { instance = this; }
    }

    public void NewScore(List<DiceFace> resultDiceFaceList)
    {
        scoreM_Increment.SetChestCombo(0);
        scoreM_Increment.ResetCombo();

        if (DiceManager.instance.diceM_Skulls.GetCorsairDices() > 0)
        {
            scoreM_Increment.CorsairCombo(DiceManager.instance.diceM_Skulls.GetCorsairDices());
            return;
        }

        if (!DiceManager.instance.diceM_Skulls.CheckSkulls(3))
        {
            scoreM_Increment.NewScoreCumulFaces(resultDiceFaceList);
            scoreM_Increment.NewScoreIncrement();
        }
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
