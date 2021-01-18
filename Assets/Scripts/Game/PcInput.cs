using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInput : MonoBehaviour
{
    private int _horizontalValue = default;

    private bool ShotFlag = default;

    const string horizontal= "Horizontal";

    
    private void Update()
    {
        if (Input.GetAxisRaw(horizontal) > 0)
        {
            _horizontalValue = 1;
        }
        else if (Input.GetAxisRaw(horizontal) < 0)
        {
            _horizontalValue = -1;
        }
        else
        {
            _horizontalValue = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            ShotFlag = true;
            
        }
    }

    public int GetHorizontal()
    {
        return _horizontalValue;
    }

    public bool GetShotFlag()
    {
        return ShotFlag;
    }

    public void ResetShotFlag()
    {
        ShotFlag = false;
    }


}
