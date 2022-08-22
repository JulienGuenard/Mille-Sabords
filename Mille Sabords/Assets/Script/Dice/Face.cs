using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    public Dice dice;
    public DiceFace diceFace;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            dice.ChangeDiceFace(diceFace);
        }
    }
}
