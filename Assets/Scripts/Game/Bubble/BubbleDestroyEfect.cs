using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDestroyEfect : MonoBehaviour
{
    const string destroyTag = "Destroy";

    const string animTrigger = "destroy";

    private Animator bubbleAnim = default;

    private Rigidbody bubbleRig = default;

    private void Start()
    {
        bubbleAnim = GetComponent<Animator>();

        bubbleRig = GetComponent<Rigidbody>();
    }

    public void DestroyEfect()
    {
        bubbleAnim.SetTrigger(animTrigger);

        StartCoroutine(DestroyObj());
    }

    public void Drop()
    {
        bubbleRig.constraints = RigidbodyConstraints.FreezeRotation;
        bubbleRig.useGravity = true;

        StartCoroutine(DestroyObj());
    }

    IEnumerator DestroyObj()
    {
        GetComponent<SphereCollider>().enabled = false;

        gameObject.tag = destroyTag;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);

        yield break;
    }
}
