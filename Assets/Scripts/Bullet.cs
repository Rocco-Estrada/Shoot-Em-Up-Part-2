using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float ceiling = 5;
    private float floor = -5;

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > ceiling || this.transform.position.y < floor)
        {
            Destroy(this.gameObject);
        }
    }
}
