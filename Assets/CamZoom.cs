using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    public GameObject Camera;
    public bool ZoomEnabled;
    private float FovLast;
    private Camera Pcam;
    private float CurrentZoom;
    void Start()
    {
        Pcam = Camera.GetComponent<Camera>();
        FovLast = Pcam.fieldOfView;
        CurrentZoom = FovLast;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3)) 
        {
            ZoomEnabled = !ZoomEnabled;
            Debug.Log(ZoomEnabled);
            Debug.Log(Pcam.fieldOfView);
        }
        if (ZoomEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("Made it in loop!!");
                CurrentZoom += Input.mouseScrollDelta.y;
                Pcam.fieldOfView += CurrentZoom;
            }
        }
        else
        {
            Pcam.fieldOfView = FovLast;
        }

    }
}
