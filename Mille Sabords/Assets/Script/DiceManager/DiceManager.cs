using UnityEngine;

public class DiceManager : DiceManagerHeritage
{
    static public DiceManager instance;

    new void Awake()
    {
        base.Awake();
        if (instance == null) { instance = this; }
    }

    private void Start()
    {
        diceM_Select.SelectAllDices();
    }

    void Update()
    {
        // Quand les dés sont bien retombés, fini le tour
        if (diceM_Roll.GetIsRolling() 
            && diceM_Lists.GetResultDiceFaceList().Count == diceM_Lists.GetDiceList().Count)
        {
            DicesDown();
        }
    }

    public void Roll() // Lance les dés grâce au bouton
    {
        if (diceM_Roll.GetIsRolling()) return;

        UIManager.instance.DesactiveUI();
        diceM_Roll.SetIsRolling(true);
        diceM_Lists.ClearFaceList();
        ScoreManager.instance.ResetScore();
        diceM_Throw.ThrowDices();
    }

    public void ResetDices() // Reset la valeur des dés pour le prochain joueur
    {
        foreach(Dice d in diceM_Lists.GetDiceList())
        {
            d.ChangeDiceFace(DiceFace.Perroquet);
            d.SetFirstRoll();
        }

        diceM_Roll.SetIsFirstRoll(true);
        diceM_Skulls.ResetSkullNumber();
        diceM_Skulls.SetCorsairDices(0);
        diceM_Select.SelectAllDices();
        diceM_Roll.SetIsRolling(false);
    }

    void DicesDown() // Fini le tour quand les dés sont tous bien tombés
    {
        UIManager.instance.ActiveUI();
        // +4 Skulls : Dés corsaires
        if (diceM_Skulls.CheckSkulls(4) 
            && diceM_Roll.GetIsFirstRoll() 
            && diceM_Skulls.GetSkullDices() > diceM_Skulls.GetCorsairDices())
        {
            diceM_Roll.SetIsFirstRoll(true);
            diceM_Skulls.SetCorsairDices(diceM_Skulls.GetSkullDices());
        }
        // +3 Skulls : Round over
        else if (diceM_Skulls.CheckSkulls(3))
        {
            if (diceM_Skulls.GetCorsairDices() == 0) ScoreManager.instance.ResetScore();

            GameManager.instance.gameM_Turn.SetRoundIsOver(true);
            GameManager.instance.gameM_Turn.RoundOver();
            diceM_Roll.SetIsFirstRoll(false);
        }
        else
        {
            diceM_Roll.SetIsFirstRoll(false);
        }
        // Décompte du score
        ScoreManager.instance.NewScore(diceM_Lists.GetResultDiceFaceList());
        diceM_Roll.SetIsRolling(false);
    }
}
