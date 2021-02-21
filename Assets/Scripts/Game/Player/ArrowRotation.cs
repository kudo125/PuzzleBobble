using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    private Transform batteryTransform = default;

    private float angle = default;

    private void Start()
    {
        batteryTransform = GetComponent<Transform>();
    }

    public void Rotation(float horizontal)
    {
        if (horizontal < 0 && angle < 60f)
        {
            angle += 2f;
            batteryTransform.rotation = Quaternion.Euler(0, 0, batteryTransform.rotation.z + angle);
        }
        else if (horizontal > 0 && angle > -60f)
        {
            angle -= 2f;
            batteryTransform.rotation = Quaternion.Euler(0, 0, batteryTransform.rotation.z + angle);
        }
    }
}
