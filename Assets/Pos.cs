using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pos : MonoBehaviour
{

    public TMP_Text PosText;
    public GameObject Player;
    private int updatetime;
  
    void Start()
    {
        PosText = GetComponent<TMP_Text>();
        updatetime = 0;
        PosText.color = new Color32(255, 255, 255, 255);
    }

  
    void Update()
    {
        updatetime++;
        if (updatetime % 10 == 0) 
        {
            PosText.text = ("PosX: " + Player.transform.position.x + "\n" + "PosY: " + Player.transform.position.y + "\n" + "PosZ: " + Player.transform.position.z);
        }
    }
}
