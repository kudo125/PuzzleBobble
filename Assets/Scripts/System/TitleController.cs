using UnityEngine;
using UniRx;

public class TitleController : MonoBehaviour
{
    private void Start()
    {
        //Bボタンでタイトルからメニューシーンに移動
        KeyInput.Instance.OnInputB
            .Where(scene => GameStatus.SceneStatusReactivePropety.Value==SceneStatusEnum.Title)
            .Subscribe(scene => SceneManager.Instance.CallSceneChange(SceneStatusEnum.Menu))
            .AddTo(this);
    }
}
