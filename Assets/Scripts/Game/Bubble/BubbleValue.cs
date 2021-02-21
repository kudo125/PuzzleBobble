using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleValue : MonoBehaviour
{
    [SerializeField]
    private int _bubbleValue = default;

    public void SetBubbleValue(int setValue)
    {
        _bubbleValue = setValue;
    }

    public int GetBubbleValue()
    {
        return _bubbleValue;
    }

}
