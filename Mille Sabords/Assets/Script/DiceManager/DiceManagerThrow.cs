using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManagerThrow : MonoBehaviour
{
    public Vector3 diceRollForce;

    public void ThrowDices()
    {
        foreach (Dice d in DiceManager.instance.diceM_Lists.GetDiceList())
        {
            if (DiceManager.instance.diceM_Lists.GetSelectedDiceList().Contains(d))
            {
                d.MakeStatic(false);
                Vector3 force = diceRollForce;
                force.x *= Random.Range(0.5f, 2f);
                force.y *= Random.Range(0.5f, 2f);
                force.z *= Random.Range(0.5f, 2f);
                d.Roll(force);
            }
            else
            {
                d.MakeStatic(true);
            }
        }
    }
}
