using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManagerRoll : MonoBehaviour
{
    bool isRolling = false;

    public bool GetIsRolling() { return isRolling; }
    public void SetIsRolling(bool state) { isRolling = state; }
        
    public bool CheckRoll()
    {
        if (DiceManager.instance.diceM_Lists.GetSelectedDiceList().Count <= 1) return false;
        return true;
    }

    public void RollBegin()
    {
        SetIsRolling(true);
    }

    public void RollEnd()
    {
        GameManager.instance.gameM_Phase.EndPhase();
    }
}
