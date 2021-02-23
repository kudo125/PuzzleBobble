using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    private Transform _batteryTransform = default;

    private float _angle = default;

    private void Start()
    {
        _batteryTransform = GetComponent<Transform>();
    }

    public void Rotation(float horizontal)
    {
        if (horizontal < 0 && _angle < 60f)
        {
            _angle += 2f;
            _batteryTransform.rotation = Quaternion.Euler(0, 0, _batteryTransform.rotation.z + _angle);
        }
        else if (horizontal > 0 && _angle > -60f)
        {
            _angle -= 2f;
            _batteryTransform.rotation = Quaternion.Euler(0, 0, _batteryTransform.rotation.z + _angle);
        }
    }
}
