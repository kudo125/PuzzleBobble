using UnityEngine;
using System.Collections;
using UniRx;

public class PlayerController : MonoBehaviour
{
    private ArrowRotation _arrowRotation = default;
    private BubbleShot    _bubbleShot    = default;


    private void Start()
    {
        _arrowRotation = GetComponent<ArrowRotation>();
        _bubbleShot    = GetComponent<BubbleShot>();

        //Bボタンでバブル発射
        KeyInput.Instance.OnInputB
            .Where(shot=>GameStatus.PlayerStatusReactiveProperty.Value==PlayerStatusEnum.ShotReady)
            .Subscribe(shot => _bubbleShot.Shot())
            .AddTo(this);

        //左右キーで左右に回転
        KeyInput.Instance.OnInputHorizontal
            .Where(horizontal=>GameStatus.GameStatusReactivePropety.Value!=GameStatusEnum.ArrayCheck)
            .Subscribe(horizontal => _arrowRotation.Rotation(horizontal))
            .AddTo(this);

        //プレイヤーステータスがSetBubbleの時
        GameStatus.PlayerStatusReactiveProperty
            .DistinctUntilChanged()
            .Where(status => status == PlayerStatusEnum.SetBubble)
            .Subscribe(_ => StartCoroutine(BubbleReload.Instance.Reload()))
            .AddTo(this);
    }
}
