using UnityEngine;
using TMPro;

public class UIManager_Feedbacks : MonoBehaviour
{
    public TextMeshProUGUI playerTurnText;

    public void ChangePlayerTurnText(int player)
    {
        switch (player)
        {
            case 1:
                playerTurnText.text = "<color=#00B6FF>PLAYER ONE<color=#FFFFFF>'S TURN";
                break;
            case 2:
                playerTurnText.text = "<color=#E7003A>PLAYER TWO<color=#FFFFFF>'S TURN";
                break;
        }
    }
}
