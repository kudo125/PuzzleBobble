using UnityEngine;
using UniRx;

public class StageManager : MonoBehaviour
{
    private void Start()
    {
        //ゲームステータスがNoneの時
        //ステージ読み込み
        GameStatus.GameStatusReactivePropety
            .DistinctUntilChanged()
            .Where(status => status == GameStatusEnum.None)
            .Subscribe(_ => LoadCsv.Instance.LoadStage())
            .AddTo(this);

        //ゲームステータスがLoadedStageの時
        //ステージ生成
        GameStatus.GameStatusReactivePropety
            .DistinctUntilChanged()
            .Where(status => status == GameStatusEnum.LoadedStage)
            .Subscribe(_ => StageCreate.Instance.SetStage())
            .AddTo(this);
    }

    private void StageGenerate()
    {
        StageCreate.Instance.SetStage();
        
    }
}
