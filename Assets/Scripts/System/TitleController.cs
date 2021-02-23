using UnityEngine;
using System;
using UniRx;

public class TitleController : MonoBehaviour
{
    private void Start()
    {
        //Bボタンでタイトルからメニューシーンに移動
        KeyInput.Instance.OnInputB
            .ThrottleFirst(TimeSpan.FromSeconds(1))
            .Where(scene => GameStatus.SceneStatusReactivePropety.Value==SceneStatusEnum.Title)
            .Subscribe(scene => ButtonDown())
            .AddTo(this);
    }

    private void ButtonDown()
    {
        AudioController.Instance.ClickSePlay();
        SceneManager.Instance.CallSceneChange(SceneStatusEnum.Menu);
    }
}
