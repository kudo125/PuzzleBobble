using System.Collections;
using UnityEngine;

public class BubbleDestroyEfect : MonoBehaviour
{
    private const string ANIM_TRIGGER = "destroy";

    private Animator _bubbleAnim = default;

    private Rigidbody _bubbleRig = default;

    public void DestroyEfect()
    {

        _bubbleAnim = GetComponent<Animator>();

        _bubbleAnim.SetTrigger(ANIM_TRIGGER);

        StartCoroutine(DestroyObj());
    }

    public void Drop()
    {
        _bubbleRig = GetComponent<Rigidbody>();

        _bubbleRig.constraints = RigidbodyConstraints.FreezeRotation;
        _bubbleRig.useGravity = true;

        StartCoroutine(DestroyObj());
    }

    IEnumerator DestroyObj()
    {
        GetComponent<SphereCollider>().enabled = false;

        gameObject.tag = Tags.DESTROY;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);

        yield break;
    }
}
