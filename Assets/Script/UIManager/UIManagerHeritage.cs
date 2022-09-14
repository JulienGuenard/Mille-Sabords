using UnityEngine;

public class UIManagerHeritage : MonoBehaviour
{
    [HideInInspector] public UIManagerButtons uiM_Buttons;
    [HideInInspector] public UIManagerFeedbacks uiM_Feedbacks;
    [HideInInspector] public UIManagerMenu uiM_Menu;
    [HideInInspector] public UIManagerWinner uiM_Winner;

    virtual public void Awake()
    {
        uiM_Buttons = GetComponent<UIManagerButtons>();
        uiM_Feedbacks = GetComponent<UIManagerFeedbacks>();
        uiM_Menu = GetComponent<UIManagerMenu>();
        uiM_Winner = GetComponent<UIManagerWinner>();
    }
}
