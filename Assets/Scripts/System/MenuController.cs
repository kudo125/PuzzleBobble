using UnityEngine;
using UniRx;

public class MenuController : MonoBehaviour
{
    private ModeSelect   modeSelect   = default;

    private void Start()
    {
        modeSelect = GetComponent<ModeSelect>();

        //Bボタンでメニューからゲームシーンに移動
        KeyInput.Instance.OnInputB
            .Where(scene => GameStatus.SceneStatusReactivePropety.Value==SceneStatusEnum.Menu)
            .Subscribe(scene => SceneManager.Instance.CallSceneChange(SceneStatusEnum.Game))
            .AddTo(this);

        //上下キーでカーソル移動
        KeyInput.Instance.OnInputVertical
            .Where(verticl => GameStatus.SceneStatusReactivePropety.Value==SceneStatusEnum.Menu)
            .Subscribe(vertical => modeSelect.Select(vertical))
            .AddTo(this);
    }
}
