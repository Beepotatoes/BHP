using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevOverlay : MonoBehaviour
{
    private bool DevEnabled;
    public GameObject Panel;
    void Start()
    {
        DevEnabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log(DevEnabled);
            DevEnabled = !DevEnabled;
            Panel.SetActive(DevEnabled);
        }
    }
}