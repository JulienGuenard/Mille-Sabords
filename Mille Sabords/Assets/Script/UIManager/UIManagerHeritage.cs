using UnityEngine;

public class UIManagerHeritage : MonoBehaviour
{
    [HideInInspector] public UIManagerButtons uiM_Buttons;
    [HideInInspector] public UIManagerFeedbacks uiM_Feedbacks;

    virtual public void Awake()
    {
        uiM_Buttons = GetComponent<UIManagerButtons>();
        uiM_Feedbacks = GetComponent<UIManagerFeedbacks>();
    }
}
