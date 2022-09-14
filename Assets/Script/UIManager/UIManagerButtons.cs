using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerButtons : UIManagerHeritage
{
    [Range(0, 1)] public float btn_Transparency;

    public GameObject btnRoll;
    [HideInInspector] public TextMeshProUGUI btnRoll_Text;
    [HideInInspector] public Image btnRoll_Image;
    [HideInInspector] public Button btnRoll_Button;

    public GameObject btnKeep;
    [HideInInspector] public TextMeshProUGUI btnKeep_Text;
    [HideInInspector] public Image btnKeep_Image;
    [HideInInspector] public Button btnKeep_Button;

    new void Awake()
    {
        base.Awake();

        btnRoll_Text =      btnRoll.GetComponentInChildren<TextMeshProUGUI>();
        btnRoll_Image =     btnRoll.GetComponent<Image>();
        btnRoll_Button =    btnRoll.GetComponent<Button>();

        btnKeep_Text =      btnKeep.GetComponentInChildren<TextMeshProUGUI>();
        btnKeep_Image =     btnKeep.GetComponent<Image>();
        btnKeep_Button =    btnKeep.GetComponent<Button>();

        btnKeep_Image.color = new Color(1, 1, 1, btn_Transparency);
        btnKeep_Button.interactable = false;
    }

    public void DisableRoll()
    {
        DisableButton(btnRoll_Image, btnRoll_Button);
    }

    public void DisableButton(Image image, Button btn)
    {
        image.color = new Color(1, 1, 1, btn_Transparency);
        btn.interactable = false;
    }

    public void EnableButton(Image image, Button btn)
    {
        image.color = new Color(1, 1, 1, 1);
        btn.interactable = true;
    }

    public void RenameButton(TextMeshProUGUI btnText, string newText)
    {
        btnText.text = newText;
    }
}
