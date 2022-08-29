using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManagerLists : MonoBehaviour
{
    public List<Dice> diceList;
    List<Dice> selectedDiceList = new List<Dice>();
    List<DiceFace> resultDiceFaceList = new List<DiceFace>();

    /////////////////////////////////////////////////////////////////////////////////////////////

    void Awake()
    {
        diceList.Clear();
        diceList.AddRange(Object.FindObjectsOfType<Dice>());
    }

    public List<Dice> GetDiceList() { return diceList; }
    public List<DiceFace> GetResultDiceFaceList() { return resultDiceFaceList; }
    public List<Dice> GetSelectedDiceList() { return selectedDiceList; }
    public void AddToFaceList(DiceFace d) { GetResultDiceFaceList().Add(d); }

    public void ClearFaceList()
    {
        resultDiceFaceList.Clear();
        foreach (Dice d in diceList)
        {
            if (!selectedDiceList.Contains(d))
            {
                resultDiceFaceList.Add(d.GetDiceFace());
            }
        }
    }


}
