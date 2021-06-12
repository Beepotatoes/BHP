using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysBeam : MonoBehaviour
{
    private Vector3 BeamEnd;
    public GameObject player;
    private Physgun PhysScript;
    private LineRenderer P_Beam;
    public float Beam_StartWidth;
    public float Beam_EndWidth;
    private Vector3 Beam_Startpos;
    void Start()
    {
        P_Beam = this.gameObject.GetComponent<LineRenderer>();
        PhysScript = player.GetComponent<Physgun>();
        P_Beam.startWidth = Beam_StartWidth;
        P_Beam.endWidth = Beam_EndWidth;
    }

 
    void Update()
    {

        Beam_Startpos = this.gameObject.transform.position;
        BeamEnd = PhysScript.Phys_Beam_Endpoint;

        if (PhysScript.p_held)
        {
            P_Beam.enabled = true;
            P_Beam.SetPosition(0, Beam_Startpos);
            P_Beam.SetPosition(1, BeamEnd);
        }
        else
        { 
            P_Beam.enabled = false;
        }
   
    }
}
