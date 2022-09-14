using UnityEngine;
using TMPro;

public class UIManagerFeedbacks : UIManagerHeritage
{
    public TextMeshProUGUI playerTurnText;
    public TextMeshProUGUI P1_scoreText;
    public TextMeshProUGUI P2_scoreText;

    new private void Awake()
    {
        base.Awake();
        P1_scoreText.text = " ";
        P2_scoreText.text = " ";
    }

    public void ChangePlayerTurnText(int player)
    {
        switch (player)
        {
            case 1: playerTurnText.text = "<color=#00B6FF>PLAYER ONE<color=#FFFFFF>'S TURN"; break;
            case 2: playerTurnText.text = "<color=#E7003A>PLAYER TWO<color=#FFFFFF>'S TURN"; break;
        }
    }

    public void ChangePlayerScoreText(int player, string txt)
    {
        switch (player)
        {
            case 1: P1_scoreText.text = txt; break;
            case 2: P2_scoreText.text = txt; break;
        }
    }
}
