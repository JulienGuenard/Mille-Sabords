using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTurn : MonoBehaviour
{
    public void RoundOver()
    {
        UIManager.instance.uiM_Buttons.DisableRoll();
        DiceManager.instance.diceM_Skulls.SetCorsairDices(0);
    }
}
