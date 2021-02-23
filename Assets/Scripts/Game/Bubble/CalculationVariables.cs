using UnityEngine;

public class CalculationVariables : MonoBehaviour
{
    public static float _yMove
    {
        get; private set;
    } = default;
    public static float _xMove
    {
        get; private set;
    } = default;

    private GameObject _arrayOrigin = default;

    private void Awake()
    {
        _arrayOrigin = GameObject.FindWithTag(Tags.ORIGIN);

        //バブルの横方向の移動距離を計算
        _xMove = _arrayOrigin.GetComponent<Transform>().localScale.x;

        //バブルの縦方向の移動距離を計算
        _yMove = _arrayOrigin.GetComponent<Transform>().localScale.y * Mathf.Sqrt(3f) / 2;
    }
}
