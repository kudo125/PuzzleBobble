using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePlaced : MonoBehaviour
{
    const string placedTag = "Placed";

    /// <summary>
    /// バブルを配置済みに変更
    /// </summary>
    public void Placed()
    {
        gameObject.tag = placedTag;

        Rigidbody bubbleRig = GetComponent<Rigidbody>();

        bubbleRig.constraints = RigidbodyConstraints.FreezeAll;
    }
}
