using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPhase : MonoBehaviour
{
    public void EndPhase()
    {
        UIManager.instance.EndPhase_DesactiveUI();

        if (DiceManager.instance.diceM_Lists.GetResultDiceFaceList() == null) return;

        DiceManager.instance.diceM_Skulls.CheckSkulls();
        DiceManager.instance.diceM_Roll.SetIsRolling(false);

        ScoreManager.instance.NewScore(DiceManager.instance.diceM_Lists.GetResultDiceFaceList());


    }
}
