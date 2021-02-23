using UnityEngine;
using UniRx;
using System;

public class MenuController : MonoBehaviour
{
    private ModeSelect   modeSelect   = default;

    private void Start()
    {
        modeSelect = GetComponent<ModeSelect>();

        //Bボタンでメニューからゲームシーンに移動
        KeyInput.Instance.OnInputB
            .ThrottleFirst(TimeSpan.FromSeconds(1))
            .Where(scene => GameStatus.SceneStatusReactivePropety.Value==SceneStatusEnum.Menu)
            .Subscribe(scene => ButtonDown())
            .AddTo(this);

        //上下キーでカーソル移動
        KeyInput.Instance.OnInputVertical
            .Where(verticl => GameStatus.SceneStatusReactivePropety.Value==SceneStatusEnum.Menu)
            .Subscribe(vertical => modeSelect.Select(vertical))
            .AddTo(this);
    }

    private void ButtonDown()
    {
        AudioController.Instance.ClickSePlay();
        SceneManager.Instance.CallSceneChange(SceneStatusEnum.Game);
    }
}
