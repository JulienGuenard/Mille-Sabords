using UnityEngine;

public class ScoreManagerHeritage : MonoBehaviour
{
    [HideInInspector] public ScoreManagerIncrement scoreM_Increment;
    [HideInInspector] public ScoreManagerKeep scoreM_Keep;

    virtual public void Awake()
    {
        scoreM_Increment = GetComponent<ScoreManagerIncrement>();
        scoreM_Keep = GetComponent<ScoreManagerKeep>();
    }
}
