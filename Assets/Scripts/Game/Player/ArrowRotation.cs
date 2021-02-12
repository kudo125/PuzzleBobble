using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    private Transform batteryTransform = default;

    private GameObject inputObj=default;

    private KeyInput keyInput = default;

    private bool rotationReady = default;

    private float angle = default;

    private void Start()
    {
        inputObj = GameObject.FindWithTag("Input");
        keyInput = inputObj.GetComponent<KeyInput>();
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
