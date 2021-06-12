using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physgun : MonoBehaviour
{
    [SerializeField] private Transform Camtrans = null;
    private RaycastHit RayCastFocus;
    public float max_pickable_dis;
    public bool p_held = false;
    private float p_dis;
    private Transform p_trans;
    private Vector3 p_target;
    public Vector3 Phys_Beam_Endpoint;
    private Vector3 p_angle;
    private Vector3 p_force;
    public float p_speed = 500;

    
    void Start()
    {
        Camtrans = GetComponentInChildren<Camera>().transform;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Ray ray = new Ray(Camtrans.position, Camtrans.forward);
            if (Physics.Raycast(ray, out RayCastFocus, max_pickable_dis))            
            {
                if (RayCastFocus.collider.transform.tag == "Prop_Pickable" || RayCastFocus.collider.transform.tag == "Prop_Pickable_Heavy")
                {
                    p_trans = RayCastFocus.collider.transform;
                    p_held = true;
                    p_angle = RayCastFocus.collider.transform.eulerAngles;
                } 
            }
            if (p_held) 
            {
                p_dis = RayCastFocus.distance;
                RayCastFocus.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            if (p_held) 
            {
                p_held = false;
                RayCastFocus.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
        if (Input.mouseScrollDelta.y != 0) 
        {
            p_dis += Input.mouseScrollDelta.y;
        }

   
    }

    private void FixedUpdate()
    {
        if (p_held) 
        {
            p_dis = Mathf.Clamp(p_dis, 2, 1000);
            p_target = Camtrans.forward * p_dis + Camtrans.position;
            Phys_Beam_Endpoint = RayCastFocus.collider.transform.position;
            p_force = p_target - Phys_Beam_Endpoint;
            RayCastFocus.collider.attachedRigidbody.AddForce(p_force * p_speed);
            RayCastFocus.collider.attachedRigidbody.velocity = RayCastFocus.collider.attachedRigidbody.velocity / 1.5f;
            if (Input.GetKey(KeyCode.E)) 
            {
                p_angle.x += Input.GetAxis("Mouse Y");
                p_angle.y += Input.GetAxis("Mouse X");
            }
            RayCastFocus.collider.transform.eulerAngles = p_angle;
        }
        

    }


}
