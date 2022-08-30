using UnityEngine;

public class GameManagerPlayer : GameManagerHeritage
{
    int playerTurn = 1;

    public int GetPlayerTurn()
    {
        return playerTurn;
    }

    public void NextPlayerTurn()
    {
        playerTurn++;
        if (playerTurn >= 3) playerTurn = 1;

        UIManager.instance.uiM_Feedbacks.ChangePlayerTurnText(playerTurn);
        gameM_Turn.SetRoundIsOver(false);
    }
}
