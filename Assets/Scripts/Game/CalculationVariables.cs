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

        _xMove= arrayOrigin.GetComponent<Transform>().localScale.x;

        _yMove =arrayOrigin.GetComponent<Transform>().localScale.y * Mathf.Sqrt(3f) / 2;

        print(_yMove);

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
