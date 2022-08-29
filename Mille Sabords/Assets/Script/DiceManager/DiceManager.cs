using UnityEngine;

public class DiceManager : MonoBehaviour
{
    static public DiceManager instance;

    [HideInInspector] public DiceManagerSkulls  diceM_Skulls;
    [HideInInspector] public DiceManagerRoll    diceM_Roll;
    [HideInInspector] public DiceManagerLists   diceM_Lists;
    [HideInInspector] public DiceManagerThrow   diceM_Throw;
    [HideInInspector] public DiceManagerSelect  diceM_Select;

    bool isFirstRoll = true;

    private void Awake()
    {
        if (instance == null) { instance = this; }

        diceM_Skulls     = GetComponent<DiceManagerSkulls>();
        diceM_Roll       = GetComponent<DiceManagerRoll>();
        diceM_Lists      = GetComponent<DiceManagerLists>();
        diceM_Throw      = GetComponent<DiceManagerThrow>();
        diceM_Select     = GetComponent<DiceManagerSelect>();
    }

    private void Start()
    {
        diceM_Select.SelectAllDices();
    }

    void Update()
    {
        CheckAllDicesRolling();
    }

    public void ButtonRoll()
    {
        if (diceM_Roll.GetIsRolling()) return;

        diceM_Roll.RollBegin();
        diceM_Lists.ClearFaceList();
        UIManager.instance.BeginPhase_ActiveUI();
        ScoreManager.instance.ResetScore();
        diceM_Throw.ThrowDices();
    }

    public void ResetDices()
    {
        foreach(Dice d in diceM_Lists.GetDiceList())
        {
            d.ChangeDiceFace(DiceFace.Perroquet);
            d.SetFirstRoll();
        }

        isFirstRoll = true;
        diceM_Select.SelectAllDices();
        diceM_Skulls.ResetSkullNumber();
        diceM_Roll.SetIsRolling(false);
    }

    public bool GetIsFirstRoll() { return isFirstRoll; }
    public void SetIsFirstRoll(bool state) { isFirstRoll = state; }

    void CheckAllDicesRolling()
    {
        if (diceM_Roll.GetIsRolling() && diceM_Lists.GetResultDiceFaceList().Count == 8)
        {
            diceM_Roll.RollEnd();
        }
    }
}
