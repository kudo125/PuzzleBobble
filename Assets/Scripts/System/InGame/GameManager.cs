using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameManager : MonoBehaviour
{
    private GameObject audioController = default;

    private GameObject resultObj = default;

    private GameObject gameOverObj = default;


    const string resultTag = "Clear";

    const string audioTag = "Audio";

    const string gameOverTag = "GameOver";

    private SpriteRenderer resultSprite = default;

    private Text gameOveText = default;

    private bool gameOver = default;

    //------------------------------------------------------------------------------------------------------------------
 

    private void Start()
    {
        //ゲームステータスがGameStartの時
        GameStatus.GameStatusReactivePropety
            .DistinctUntilChanged()
            .Where(status => status == GameStatusEnum.GameStart)
            .Subscribe(_ => StartCoroutine(StartDelay()))
            .AddTo(this);


        //ゲームステータスがConnectionCheckの時
        GameStatus.GameStatusReactivePropety
           .DistinctUntilChanged()
           .Where(status => status == GameStatusEnum.ConnectionCheck)
           .Subscribe(_ => ConnectionCheck.Instance.AdjacentCheck())
           .AddTo(this);

        //ゲームステータスがDestroyの時
        GameStatus.GameStatusReactivePropety
           .DistinctUntilChanged()
           .Where(status => status == GameStatusEnum.Destroy)
           .Subscribe(_ => DestroyObjects.Instance.BubbleDestroy())
           .AddTo(this);

        //ゲームステータスがHangingの時
        GameStatus.GameStatusReactivePropety
           .DistinctUntilChanged()
           .Where(status => status == GameStatusEnum.Hanging)
           .Subscribe(_ => HangingCheck.Instance.TargetObjectSearch())
           .AddTo(this);

        //ゲームステータスがIdleでプレイヤーステータスがShotExecutedの時
        GameStatus.GameStatusReactivePropety
          .DistinctUntilChanged()
          .Where(status => status == GameStatusEnum.Idle
                 && GameStatus.PlayerStatusReactiveProperty.Value == PlayerStatusEnum.ShotExecuted)
          .Subscribe(status=> GameStatus.PlayerStatusReactiveProperty.Value=PlayerStatusEnum.ShotReady)
          .AddTo(this);
    }

    public void GameStart()
    {
       
        resultObj = GameObject.FindWithTag(resultTag);
        gameOverObj = GameObject.FindWithTag(gameOverTag);
        audioController = GameObject.FindWithTag(audioTag);
        resultSprite = resultObj.GetComponent<SpriteRenderer>();
        gameOveText = gameOverObj.GetComponent<Text>();
        
    }

    private IEnumerator StartDelay()
    {
        //ゲームスタート時バブルをセット
        NextBubble.Instance.NextBubbleSet();
        NextBubble.Instance.SetShotBubble();

        yield return new WaitForSeconds(3f);

        GameStatus.PlayerStatusReactiveProperty.Value = PlayerStatusEnum.ShotReady;

        yield break;
    }

    //--------------------------------------------------------別クラス
    public void GameEndCheck(int[,] array)
    {
        int bubbleCount = default;

        for (int i = 0; i < array.GetLength(0); ++i)
        {
            for (int j = 0; j < array.GetLength(1); ++j)
            {
                if (array[i, j] > 0)
                {
                    bubbleCount++;
                }
            }
        }

        if (gameOver)
        {
            StartCoroutine(GameOver());
        }
        else if (bubbleCount == 0)
        {
           StartCoroutine(GameClear());
        }
        
    }

    public void GameEnd()
    {
        StartCoroutine(GameOver());
    }

    //--------------------------------------------------------------------------------------- AudioManagerに移動
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        audioController.GetComponent<AudioController>().GameOverSE();
        gameOveText.enabled = true;
        yield return new WaitForSeconds(5f);
        yield break;
    }

    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(0.5f);
        audioController.GetComponent<AudioController>().ClearSE();
        resultSprite.enabled = true;
        yield return new WaitForSeconds(5f);
        yield break;
    }
    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーplayerControllerから呼び出し
    
}
