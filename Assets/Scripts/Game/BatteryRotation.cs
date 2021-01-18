using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRotation : MonoBehaviour
{
    private Transform batteryTransform = default;

    private GameObject inputObj=default;

    private PcInput pcInput = default;

    private bool rotationReady = default;

    private float angle = default;

    private void Start()
    {
        inputObj = GameObject.FindWithTag("Input");
        pcInput = inputObj.GetComponent<PcInput>();
        batteryTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (pcInput.GetHorizontal() != 0)
        {
            rotationReady = true;
        }
        else
        {
            rotationReady = false;
        }
        
    }

    private void FixedUpdate()
    {
        if (rotationReady)
        {
            Rotation(pcInput.GetHorizontal());
        }
    }

    private void Rotation(int horizontal)
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
