using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManagerSkulls : MonoBehaviour
{

    int skullNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (skullNumber >= 3)
        {
            GameManager.instance.RoundOver();
            ScoreManager.instance.ResetScore();
        }
    }

    public void AddSkullNumber()
    {
        skullNumber++;
    }

    public void ResetSkullNumber()
    {
        skullNumber = 0;
    }
}
