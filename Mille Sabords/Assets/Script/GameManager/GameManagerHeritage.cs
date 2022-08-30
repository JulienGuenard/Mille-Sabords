using UnityEngine;

public class GameManagerHeritage : MonoBehaviour
{
    [HideInInspector] public GameManagerPlayer gameM_Player;
    [HideInInspector] public GameManagerTurn gameM_Turn;

    virtual public void Awake()
    {
        gameM_Player = GetComponent<GameManagerPlayer>();
        gameM_Turn = GetComponent<GameManagerTurn>();
    }
}
