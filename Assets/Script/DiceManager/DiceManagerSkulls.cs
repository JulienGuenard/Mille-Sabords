using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManagerSkulls : DiceManagerHeritage
{
    int skullNumber;
    int corsairDices = 0;

    public int GetCorsairDices() { return corsairDices; }
    public void SetCorsairDices(int value) { corsairDices = value; }

    public int GetSkullDices() { return skullNumber; }
    public void AddSkullNumber() { skullNumber++; }
    public void ResetSkullNumber() { skullNumber = 0; }

    public bool CheckSkulls(int number)
    {
        if (skullNumber >= number) { return true; }
        return false;
    }
}
