using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawn : MonoBehaviour
{
    private int framecount = 0;
    public Object prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        framecount++ ;
        if (framecount % 1 == 0) 
        {
            Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }
}
