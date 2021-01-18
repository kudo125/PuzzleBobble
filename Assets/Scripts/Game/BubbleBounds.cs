using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBounds : MonoBehaviour
{
    private Rigidbody bubbleRig = default;

    private int boundsDirection = default;

    private void Start()
    {
        bubbleRig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.x > 2.2f&&boundsDirection>-1)
        {
            bubbleRig.velocity = new Vector3(-bubbleRig.velocity.x,bubbleRig.velocity.y);
            boundsDirection = -1;
        }
        else if(transform.position.x < -2.2f&&boundsDirection<1)
        {
            bubbleRig.velocity = new Vector3(-bubbleRig.velocity.x, bubbleRig.velocity.y);
            boundsDirection = 1;
        }
    }
}
