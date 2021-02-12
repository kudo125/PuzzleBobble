using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationVariables : MonoBehaviour
{
    private float _yMove = default;
    private float _xMove = default;

    private GameObject arrayOrigin=default;

    private void Awake()
    {
        arrayOrigin = GameObject.FindWithTag("Origin");

        //バブルの横方向の移動距離を計算
        _xMove= arrayOrigin.GetComponent<Transform>().localScale.x;

        //バブルの縦方向の移動距離を計算
        _yMove =arrayOrigin.GetComponent<Transform>().localScale.y * Mathf.Sqrt(3f) / 2;
    }

    public float GetYMove()
    {
        return _yMove;
    }
    public float GetXMove()
    {
        return _xMove;
    }
}
