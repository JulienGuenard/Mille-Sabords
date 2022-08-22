using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    static public UIManager instance;

    [Range(0, 1)] public float btn_Transparency;

    public GameObject btnRoll;
    TextMeshProUGUI btnRoll_Text;
    Image btnRoll_Image;
    Button btnRoll_Button;

    public GameObject btnKeep;
    TextMeshProUGUI btnKeep_Text;
    Image btnKeep_Image;
    Button btnKeep_Button;

    public TextMeshProUGUI playerTurnText;

    bool isDisabled = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        btnRoll_Text = btnRoll.GetComponentInChildren<TextMeshProUGUI>();
        btnRoll_Image = btnRoll.GetComponent<Image>();
        btnRoll_Button = btnRoll.GetComponent<Button>();

        btnKeep_Text = btnKeep.GetComponentInChildren<TextMeshProUGUI>();
        btnKeep_Image = btnKeep.GetComponent<Image>();
        btnKeep_Button = btnKeep.GetComponent<Button>();
        btnKeep_Image.color = new Color(1, 1, 1, btn_Transparency);
        btnKeep_Button.interactable = false;
    }

    public void ChangePlayerTurnText(int player)
    {
        switch(player)
        {
            case 1:
                playerTurnText.text = "<color=#00B6FF>PLAYER ONE<color=#FFFFFF>'S TURN";
            break;
            case 2:
                playerTurnText.text = "<color=#E7003A>PLAYER TWO<color=#FFFFFF>'S TURN";
            break;
        }
    }

    public void BeginPhase_ActiveUI()
    {
        DisableButton(btnRoll_Image, btnRoll_Button);
        DisableButton(btnKeep_Image, btnKeep_Button);
    }

    public void EndPhase_DesactiveUI()
    {
        if (isDisabled) return;

        EnableButton(btnRoll_Image, btnRoll_Button);
        EnableButton(btnKeep_Image, btnKeep_Button);
        RenameButton(btnRoll_Text, "relancer");
    }

    public void OnPressButtonRoll()
    {
        DiceManager.instance.ButtonRoll();
    }

    public void OnPressButtonKeep()
    {
        ScoreManager.instance.KeepScore();
        DiceManager.instance.ResetDices();
        EnableButton(btnRoll_Image, btnRoll_Button);
    }

   /* public void DisableAllUI()
    {
        isDisabled = true;
        DisableButton(btnRoll_Image, btnRoll_Button);
        DisableButton(btnKeep_Image, btnKeep_Button);
    }*/

    public void DisableRoll()
    {
        DisableButton(btnRoll_Image, btnRoll_Button);
    }

    void DisableButton(Image image, Button btn)
    {
        image.color = new Color(1, 1, 1, btn_Transparency);
        btn.interactable = false;
    }

    void EnableButton(Image image, Button btn)
    {
        image.color = new Color(1, 1, 1, 1);
        btn.interactable = true;
    }

    void RenameButton(TextMeshProUGUI btnText, string newText)
    {
        btnText.text = newText;
    }
}
