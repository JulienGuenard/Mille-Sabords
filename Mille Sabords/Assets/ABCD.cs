using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABCD : MonoBehaviour
{
    bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated) return;

        isActivated = true;

        A1();
        A2();
        A3();
        A4();
        B1();
        B2();
        B3();
        B4();
    }

    void A1() { Debug.Log("A1"); }
    void A2() 
    { 
        Debug.Log("A2");
        Debug.Log("A2a");
        Debug.Log("A2b");
        Debug.Log("A2c");
        Debug.Log("A2d");
        Debug.Log("A2e");
        Debug.Log("A2f");
        Debug.Log("A2g");
        Debug.Log("A2h");
        Debug.Log("A2i");
        Debug.Log("A2j");
        Debug.Log("A2k");

    }
    void A3() { Debug.Log("A3"); }
    void A4() 
    { 
        Debug.Log("A4a"); 
        for(int i = 0; i < 10; i++)
        {
            Debug.Log(i);
        }
        Debug.Log("A4b");
    }

    void B1() { Debug.Log("B1"); }
    void B2() { Debug.Log("B2"); }
    void B3() { Debug.Log("B3"); }
    void B4() { Debug.Log("B4"); }

}
