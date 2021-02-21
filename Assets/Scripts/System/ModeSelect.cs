using UnityEngine;

public class ModeSelect : MonoBehaviour
{
    public void Select(float vertical)
    {
        if (vertical > 0)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        if (vertical < 0)
        {
            transform.position = new Vector3(transform.position.x, -1, transform.position.z);
        }
    }
}
