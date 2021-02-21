using UnityEngine;
using System.Collections;
using UniRx;

public class PlayerController : MonoBehaviour
{
    private ArrowRotation arrowRotation = default;
    private BubbleShot    bubbleShot    = default;


    private void Start()
    {
        arrowRotation = GetComponent<ArrowRotation>();
        bubbleShot    = GetComponent<BubbleShot>();

        //Bボタンでバブル発射
        KeyInput.Instance.OnInputB
            .Where(shot=>GameStatus.PlayerStatusReactiveProperty.Value==PlayerStatusEnum.ShotReady)
            .Subscribe(shot => bubbleShot.Shot())
            .AddTo(this);

        //左右キーで左右に回転
        KeyInput.Instance.OnInputHorizontal
            .Where(horizontal=>GameStatus.GameStatusReactivePropety.Value!=GameStatusEnum.GameOver)
            .Subscribe(horizontal => arrowRotation.Rotation(horizontal))
            .AddTo(this);

        //プレイヤーステータスがSetBubbleの時
        GameStatus.PlayerStatusReactiveProperty
            .DistinctUntilChanged()
            .Where(status => status == PlayerStatusEnum.SetBubble)
            .Subscribe(_ => StartCoroutine(BubbleReload.Instance.Reload()))
            .AddTo(this);

        //プレイヤーステータスがShotExecutedでゲームステータスがIdleの時
        GameStatus.PlayerStatusReactiveProperty
            .DistinctUntilChanged()
            .Where(status => status == PlayerStatusEnum.ShotExecuted
                   && GameStatus.GameStatusReactivePropety.Value == GameStatusEnum.Idle)
            .Subscribe(status => GameStatus.PlayerStatusReactiveProperty.Value = PlayerStatusEnum.ShotReady)
            .AddTo(this);
    }
}
