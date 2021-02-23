using UnityEngine;

public class BubbleBounds : MonoBehaviour
{
    private Rigidbody _bubbleRig = default;

    private int _boundsDirection = default;

    private void Start()
    {
        _bubbleRig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.x > 2.2f&&_boundsDirection>-1)
        {
            _bubbleRig.velocity = new Vector3(-_bubbleRig.velocity.x,_bubbleRig.velocity.y);
            _boundsDirection = -1;
        }
        else if(transform.position.x < -2.2f&&_boundsDirection<1)
        {
            _bubbleRig.velocity = new Vector3(-_bubbleRig.velocity.x, _bubbleRig.velocity.y);
            _boundsDirection = 1;
        }
    }
}
