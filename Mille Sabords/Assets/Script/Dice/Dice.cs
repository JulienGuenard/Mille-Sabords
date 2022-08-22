using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    DiceFace diceFace = DiceFace.Swords;
    Rigidbody rb;
    public GameObject diceArt;
    MeshRenderer diceArt_meshR;

    bool isFirstRoll = true;
    bool isRolling = false;
    bool isHover = false;
    bool isSelected = false;

    public Color colorNeutral;
    public Color colorHovered;
    public Color colorSelected;
    public Color colorHoveredSelected;
    public Color colorSkull;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        diceArt_meshR = diceArt.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (isRolling && rb.velocity == Vector3.zero)
        {
            GiveDiceFace();
            if (diceFace == DiceFace.Skull)
            {
                UnselectDice();
                DiceManager.instance.NewSkullDice();
            }
            MakeStatic(true);
        }

        if (isHover && Input.GetMouseButtonDown(0))
        {
            if (isSelected)
            {
                UnselectDice();
            } 
            else
            {
                ClickDice();
            }

        }
    }

    public void SetFirstRoll()
    {
        isFirstRoll = true;
    }

    public void Roll(Vector3 force)
    {
        if (isRolling) return;

        rb.velocity = Vector3.forward;
        rb.AddForce(force);
        isRolling = true;
    }

    public void MakeStatic(bool state)
    {
        rb.isKinematic = state;
    }

    public void ChangeDiceFace(DiceFace d)
    {
        diceFace = d;
    }

    public DiceFace GetDiceFace()
    {
        return diceFace;
    }

    public void SelectDice()
    {
        isSelected = true;
        if (isHover)
        {
            diceArt_meshR.material.color = colorHoveredSelected;
            return;
        }
        diceArt_meshR.material.color = colorSelected;
     }

    public void UnselectDice()
    {
        isSelected = false;
        DiceManager.instance.UnselectDice(this);

        if (diceFace != DiceFace.Skull) return;

        diceArt_meshR.material.color = colorSkull;
    }

    void ClickDice()
    {
        DiceManager.instance.SelectDice(this);
    }

    void GiveDiceFace()
    {
        isRolling = false;
        isFirstRoll = false;
        DiceManager.instance.AddToFaceList(diceFace);
    }

    private void OnMouseOver()
    {
        if (isFirstRoll) return;
        if (isRolling) return;
        if (diceFace == DiceFace.Skull) return;

        isHover = true;
        if (!isSelected)
        {
            diceArt_meshR.material.color = colorHovered;
        }else
        {
            diceArt_meshR.material.color = colorHoveredSelected;
        }
    }

    private void OnMouseExit()
    {
        if (isFirstRoll) return;
        if (isRolling) return;
        if (diceFace == DiceFace.Skull) return;

        isHover = false;
        if (!isSelected)
        {
            diceArt_meshR.material.color = colorNeutral;
        }
        else
        {
            diceArt_meshR.material.color = colorSelected;
        }
    }
}
