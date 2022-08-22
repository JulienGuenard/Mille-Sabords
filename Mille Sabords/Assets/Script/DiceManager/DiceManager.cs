    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DiceManager : MonoBehaviour
{
    public Vector3 diceRollForce;
    public List<Dice> diceList;
    List<DiceFace> resultDiceFaceList = new List<DiceFace>();

    public List<Dice> selectedDiceList = new List<Dice>();

    bool isRolling = false;

    static public DiceManager instance;

    DiceManagerSkulls diceManagerSkulls;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        diceManagerSkulls = GetComponent<DiceManagerSkulls>();
    }

    private void Start()
    {
        SelectAllDices();
    }

    void Update()
    {
        if (isRolling && resultDiceFaceList.Count == 8)
        {
            RollEnd();
        }
    }

    public void ButtonRoll()
    {
        if (!CheckRoll()) return;
        Debug.Log("aaa");
        RollBegin();
        ThrowDices();
    }

    public void SelectDice(Dice d)
    {
        if (d.GetDiceFace() == DiceFace.Skull) return;

        d.SelectDice();
        if (selectedDiceList.Contains(d))
        {
            selectedDiceList.Remove(d);
            return;
        }
        selectedDiceList.Add(d);
    }

    public void UnselectDice(Dice d)
    {
        if (selectedDiceList.Contains(d))
        {
            selectedDiceList.Remove(d);
            return;
        }
    }

    public void ResetDices()
    {
        foreach(Dice d in diceList)
        {
            d.ChangeDiceFace(DiceFace.Perroquet);
            d.SetFirstRoll();
        }
        SelectAllDices();
        diceManagerSkulls.ResetSkullNumber();
        isRolling = false;
    }

    public void AddToFaceList(DiceFace d)
    {
        resultDiceFaceList.Add(d);
    }

    public void NewSkullDice()
    {
        diceManagerSkulls.AddSkullNumber();
    }

    public List<DiceFace> GetResultDiceFaceList()
    {
        return resultDiceFaceList;
    }

    bool CheckRoll()
    {
        if (selectedDiceList.Count <= 1) return false;
        return true;
    }

    void RollBegin()
    {
        isRolling = true;
        ClearFaceList();
        GameManager.instance.BeginPhase();
    }

    void RollEnd()
    {
        isRolling = false;
        GameManager.instance.EndPhase();
    }

    void ThrowDices()
    {
        foreach (Dice d in diceList)
        {
            if (selectedDiceList.Contains(d))
            {
                d.MakeStatic(false);
                Vector3 force = diceRollForce;
                force.x *= Random.Range(0.5f, 2f);
                force.y *= Random.Range(0.5f, 2f);
                force.z *= Random.Range(0.5f, 2f);
                d.Roll(force);
            }else
            {
                d.MakeStatic(true);
            }
        }
    }

    void ClearFaceList()
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

    void SelectAllDices()
    {

        foreach (Dice d in diceList)
        {
            UnselectDice(d);
            SelectDice(d);
        }
    }
}
