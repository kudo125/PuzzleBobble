using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleValue : MonoBehaviour
{
    [SerializeField]
    private int bubbleValue = default;

    public void SetBubbleValue(int setValue)
    {
        bubbleValue = setValue;
    }

    public int GetBubbleValue()
    {
        return bubbleValue;
    }

}
