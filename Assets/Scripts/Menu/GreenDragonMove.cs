using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDragonMove : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetAxis("Vertical") >0)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)
        {
            transform.position = new Vector3(transform.position.x, -1, transform.position.z);
        }
    }
}
