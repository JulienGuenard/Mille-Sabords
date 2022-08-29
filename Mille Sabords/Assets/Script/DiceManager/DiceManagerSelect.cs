using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManagerSelect : MonoBehaviour
{
    public void SelectDice(Dice d)
    {
        if (d.GetDiceFace() == DiceFace.Skull) return;

        d.SelectDice();
        if (DiceManager.instance.diceM_Lists.GetSelectedDiceList().Contains(d))
        {
            DiceManager.instance.diceM_Lists.GetSelectedDiceList().Remove(d);
            return;
        }
        DiceManager.instance.diceM_Lists.GetSelectedDiceList().Add(d);
    }

    public void SelectAllDices()
    {

        foreach (Dice d in DiceManager.instance.diceM_Lists.GetDiceList())
        {
            UnselectDice(d);
            SelectDice(d);
        }
    }

    public void UnselectDice(Dice d)
    {
        if (DiceManager.instance.diceM_Lists.GetSelectedDiceList().Contains(d))
        {
            DiceManager.instance.diceM_Lists.GetSelectedDiceList().Remove(d);
            return;
        }
    }
}
