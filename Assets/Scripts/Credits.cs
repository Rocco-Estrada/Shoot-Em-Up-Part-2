using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public Transform pos;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(pos.position.y < 0)
        {
            Application.LoadLevel("Main Menu");
        }
        
    }
}
