using UnityEngine;

public class DiceManagerHeritage : MonoBehaviour
{
    [HideInInspector] public DiceManagerSkulls diceM_Skulls;
    [HideInInspector] public DiceManagerRoll diceM_Roll;
    [HideInInspector] public DiceManagerLists diceM_Lists;
    [HideInInspector] public DiceManagerThrow diceM_Throw;
    [HideInInspector] public DiceManagerSelect diceM_Select;
    virtual public void Awake()
    {
        diceM_Skulls = GetComponent<DiceManagerSkulls>();
        diceM_Roll = GetComponent<DiceManagerRoll>();
        diceM_Lists = GetComponent<DiceManagerLists>();
        diceM_Throw = GetComponent<DiceManagerThrow>();
        diceM_Select = GetComponent<DiceManagerSelect>();
    }
}
