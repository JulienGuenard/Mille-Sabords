using UnityEngine;

public class UIManager : UIManagerHeritage
{
    static public UIManager instance;

    bool isDisabled = false;

    private new void Awake()
    {
        base.Awake();
        if (instance == null) { instance = this; }
    }

    public void OnPressButtonRoll()
    {
        DiceManager.instance.Roll();
    }

    public void OnPressButtonKeep()
    {
        ScoreManager.instance.scoreM_Keep.KeepScore();
        DiceManager.instance.ResetDices();
        uiM_Buttons.EnableButton(uiM_Buttons.btnRoll_Image, uiM_Buttons.btnRoll_Button);
    }

    public void DesactiveUI()
    {
        uiM_Buttons.DisableButton(uiM_Buttons.btnRoll_Image, uiM_Buttons.btnRoll_Button);
        uiM_Buttons.DisableButton(uiM_Buttons.btnKeep_Image, uiM_Buttons.btnKeep_Button);
    }

    public void ActiveUI()
    {
        if (isDisabled) return;

        uiM_Buttons.EnableButton(uiM_Buttons.btnRoll_Image, uiM_Buttons.btnRoll_Button);
        uiM_Buttons.EnableButton(uiM_Buttons.btnKeep_Image, uiM_Buttons.btnKeep_Button);
        uiM_Buttons.RenameButton(uiM_Buttons.btnRoll_Text, "relancer");
    }
}
