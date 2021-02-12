using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    private ArrowRotation arrowRotation = default;
    private BubbleShot    bubbleShot    = default;
    private KeyInput      keyInput      = default;

    private void Start()
    {
        //インスタンス化
        arrowRotation = GetComponent<ArrowRotation>();
        bubbleShot    = GetComponent<BubbleShot>();
        keyInput      = GameObject.FindWithTag(Tags.INPUT_TAG).GetComponent<KeyInput>();

        //Bボタンでバブル発射
        keyInput.OnInputB.Subscribe(shot => bubbleShot.Shot()).AddTo(this);

        //左右キーで左右に回転
        keyInput.OnInputHorizontal.Subscribe(horizontal => arrowRotation.Rotation(horizontal)).AddTo(this);
    }
}
