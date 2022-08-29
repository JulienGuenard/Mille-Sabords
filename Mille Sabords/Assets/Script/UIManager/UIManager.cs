using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager instance;

    [HideInInspector] public UIManager_Buttons      uiM_Buttons;
    [HideInInspector] public UIManager_Feedbacks    uiM_Feedbacks;

    bool isDisabled = false;

    private void Awake()
    {
        if (instance == null) { instance = this; }

        uiM_Buttons     = GetComponent<UIManager_Buttons>();
        uiM_Feedbacks   = GetComponent<UIManager_Feedbacks>();
    }

    public void OnPressButtonRoll()
    {
        DiceManager.instance.ButtonRoll();
    }

    public void OnPressButtonKeep()
    {
        ScoreManager.instance.scoreM_Keep.KeepScore();
        DiceManager.instance.ResetDices();
        uiM_Buttons.EnableButton(uiM_Buttons.btnRoll_Image, uiM_Buttons.btnRoll_Button);
    }

    public void BeginPhase_ActiveUI()
    {
        uiM_Buttons.DisableButton(uiM_Buttons.btnRoll_Image, uiM_Buttons.btnRoll_Button);
        uiM_Buttons.DisableButton(uiM_Buttons.btnKeep_Image, uiM_Buttons.btnKeep_Button);
    }

    public void EndPhase_DesactiveUI()
    {
        if (isDisabled) return;

        uiM_Buttons.EnableButton(uiM_Buttons.btnRoll_Image, uiM_Buttons.btnRoll_Button);
        uiM_Buttons.EnableButton(uiM_Buttons.btnKeep_Image, uiM_Buttons.btnKeep_Button);
        uiM_Buttons.RenameButton(uiM_Buttons.btnRoll_Text, "relancer");
    }
}
