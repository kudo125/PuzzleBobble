using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePlaced : MonoBehaviour
{
    /// <summary>
    /// バブルを配置済みに変更
    /// </summary>
    public void Placed()
    {
        //Tagを設置済みに変更
        gameObject.tag = Tags.PlACED;

        //設置後動かなくする
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        //不必要なスクリプトを外す
        Destroy(GetComponent<BubbleConnect>());
    }
}
