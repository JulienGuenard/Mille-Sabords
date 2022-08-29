using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManagerSkulls : MonoBehaviour
{
    int skullNumber;
    int corsairDices = 0;

    public void CheckSkulls()
    {
        Debug.Log("aa");
        Debug.Log(DiceManager.instance.GetIsFirstRoll());
        Debug.Log(skullNumber);
        if (DiceManager.instance.GetIsFirstRoll() && skullNumber >= 4)
        {
            Debug.Log("bb");
            DiceManager.instance.SetIsFirstRoll(true);
            if (corsairDices == 0 || skullNumber > corsairDices)
            {
                Debug.Log("cc");
                corsairDices = skullNumber;
            }else
            {
                Debug.Log("dd");
                GameManager.instance.gameM_Turn.RoundOver();
                ScoreManager.instance.ResetScore();
            }
        }

        if (DiceManager.instance.diceM_Roll.GetIsRolling()) return;
        if (corsairDices != 0) return;

        if (skullNumber >= 3)
        {
            GameManager.instance.gameM_Turn.RoundOver();
            ScoreManager.instance.ResetScore();
        }
    }

    public int GetCorsairDices()            { return corsairDices; }
    public void SetCorsairDices(int value)  { corsairDices = value; }

    public void AddSkullNumber()   { skullNumber++; }
    public void ResetSkullNumber() { skullNumber = 0; }
}
