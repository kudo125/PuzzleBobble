using UnityEngine;
using System;
using UniRx;

public class KeyInput : SingletonMonoBehaviour<KeyInput>
{
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL   = "Vertical";

    //入力値を送る
    private Subject<float> inputHorizontal = new Subject<float>();
    private Subject<float> inputVertical   = new Subject<float>();
    private Subject<bool>  inputB          = new Subject<bool>();
    private Subject<bool>  inputExit       = new Subject<bool>();

    //IObservableに対してSubscribeする
    public IObservable<float> OnInputHorizontal
    {
        get { return inputHorizontal; }
    }
    public IObservable<float> OnInputVertical
    {
        get { return inputVertical; }
    }
    public IObservable<bool> OnInputB
    {
        get { return inputB; }
    }
    public IObservable<bool> OnInputExit
    {
        get { return inputExit; }
    }

    private void Update()
    {
        InputHorizontal();
        InputVertical();
        InputB();
        InputExit();
    }

    /// <summary>
    /// Bボタンの入力通知
    /// </summary>
    private void InputB()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            inputB.OnNext(true);
        }
    }

    /// <summary>
    /// 横方向の入力通知
    /// </summary>
    private void InputHorizontal()
    {
        float horizontalValue = Input.GetAxisRaw(HORIZONTAL);

        if (horizontalValue != 0)
        {
            inputHorizontal.OnNext(horizontalValue);
        }
    }

    /// <summary>
    /// 縦方向の入力通知
    /// </summary>
    private void InputVertical()
    {
        float verticalValue = Input.GetAxisRaw(VERTICAL);

        if (verticalValue != 0)
        {
            inputVertical.OnNext(verticalValue);
        }
    }

    /// <summary>
    /// escape入力通知
    /// </summary>
    private void InputExit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inputExit.OnNext(true);
        }
    }
}
