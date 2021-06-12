using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float PlayerSpeed;
    private GameObject Player;
    public GameObject Camera;
    private float CameraAngleY;
    private float CameraAngleX;
    private CharacterController Cctrl;
    private Vector3 PVelo;
    private Vector3 Grav;
    
    void Start()
    {
        Player = this.gameObject;
        Cctrl = Player.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CameraAngleY += Input.GetAxis("Mouse Y");
        CameraAngleX += Input.GetAxis("Mouse X");
        if (CameraAngleY > 89) { CameraAngleY = 89; }
        if (CameraAngleY < -89) { CameraAngleY = -89; }

        PVelo = Vector3.zero;

        // basic player movement \/
        if (Input.GetKey(KeyCode.W)) { PVelo += (Player.transform.forward / 10) * PlayerSpeed; }
        if (Input.GetKey(KeyCode.S)) { PVelo -= (Player.transform.forward / 10) * PlayerSpeed; }
        if (Input.GetKey(KeyCode.A)) { PVelo -= (Player.transform.right / 10) * PlayerSpeed; }
        if (Input.GetKey(KeyCode.D)) { PVelo += (Player.transform.right / 10) * PlayerSpeed; }
        Grav -= (Player.transform.up / 250) * (Time.deltaTime * 120);

        // Gravity BABY
        if (Cctrl.isGrounded) 
        {
            Grav = Vector3.zero;
            if (Input.GetKey(KeyCode.Space)) { Grav += Player.transform.up / 7; }
        }
        // asdasd
        Cctrl.Move((PVelo + Grav) * (Time.deltaTime * 100));


        Player.transform.eulerAngles = new Vector3(0, CameraAngleX, 0);
        Camera.transform.eulerAngles = new Vector3(-CameraAngleY, Player.transform.eulerAngles.y, 0);
    }
}
