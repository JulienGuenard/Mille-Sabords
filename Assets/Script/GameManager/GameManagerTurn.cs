using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTurn : GameManagerHeritage
{
    bool roundIsOver = false;

    public void SetRoundIsOver(bool state) { roundIsOver = state; }
    public bool GetRoundIsOver() { return roundIsOver; }

    public void RoundOver()
    {
        UIManager.instance.uiM_Buttons.DisableRoll();
    }
}
