using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light Flash;
    private bool BFlash;
    void Start()
    {
        Flash = GetComponent<Light>();
        BFlash = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            BFlash = !BFlash;
            Flash.enabled = BFlash;
        }
    }
}
