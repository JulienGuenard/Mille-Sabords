using UnityEngine;

public class DiceManagerRoll : DiceManagerHeritage
{
    bool isRolling = false;
    bool isFirstRoll = true;

    public bool GetIsRolling() { return isRolling; }
    public void SetIsRolling(bool state) { isRolling = state; }

    public bool GetIsFirstRoll() { return isFirstRoll; }
    public void SetIsFirstRoll(bool state) { isFirstRoll = state; }

    public bool CheckRoll()
    {
        if (DiceManager.instance.diceM_Lists.GetSelectedDiceList().Count <= 1) return false;
        return true;
    }
}
