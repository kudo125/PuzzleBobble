using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameManager : MonoBehaviour
{
    private GameObject _audioController = default;

    private GameObject _resultObj = default;

    private GameObject _gameOverObj = default;

    private SpriteRenderer _resultSprite = default;

    private Text _gameOveText = default;

    private bool _gameOver = default;

    private bool _shotReady = default;

    private bool _idle = default;

    private void Awake()
    {

        _resultObj = GameObject.FindWithTag(Tags.CLEAR);
        _gameOverObj = GameObject.FindWithTag(Tags.GAME_OVER);
        _audioController = GameObject.FindWithTag(Tags.AUDIO);
        _resultSprite = _resultObj.GetComponent<SpriteRenderer>();
        _gameOveText = _gameOverObj.GetComponent<Text>();

    }

    private void Update()
    {
        if (_shotReady && _idle)
        {
            GameStatus.PlayerStatusReactiveProperty.Value = PlayerStatusEnum.ShotReady;
            _idle = default;
            _shotReady = default;
        }
    }

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

        //ゲームステータスがArrayCheckの時
        GameStatus.GameStatusReactivePropety
          .DistinctUntilChanged()
          .Where(status => status == GameStatusEnum.ArrayCheck)
          .Subscribe(status => ArrayCheck())
          .AddTo(this);

        //ゲームステータスがIdleの時
        GameStatus.GameStatusReactivePropety
          .DistinctUntilChanged()
          .Where(status => status == GameStatusEnum.Idle)
          .Subscribe(status => _idle=true)
          .AddTo(this);

        //プレイヤーステータスがShotExecutedの時
        GameStatus.PlayerStatusReactiveProperty
          .DistinctUntilChanged()
          .Where(status => status == PlayerStatusEnum.ShotExecuted)
          .Subscribe(status => _shotReady = true)
          .AddTo(this);
    }

    private IEnumerator StartDelay()
    {
        AudioController.Instance.BgmPlay();

        //ゲームスタート時バブルをセット
        NextBubble.Instance.NextBubbleSet();
        NextBubble.Instance.SetShotBubble();

        GameStatus.PlayerStatusReactiveProperty.Value = PlayerStatusEnum.ShotReady;
        yield break;
    }

    public void ArrayCheck()
    {
        int bubbleCount = default;

        for (int i = 0; i < ArrayData.Array.GetLength(0); ++i)
        {
            for (int j = 0; j < ArrayData.Array.GetLength(1); ++j)
            {
                if (i == ArrayData.Array.GetLength(0)-1 && ArrayData.Array[i, j] > 0) 
                {
                    _gameOver = true;
                }

                if (ArrayData.Array[i, j] > 0)
                {
                    bubbleCount++;
                }
            }
        }

        if (_gameOver)
        {
            StartCoroutine(GameOver());
        }
        else if (bubbleCount == 0)
        {
            StartCoroutine(GameClear());
        }
        else
        {
            //判定を取れなければゲームステータス変更
            GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.Idle;
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        _audioController.GetComponent<AudioController>().GameOverSePlay();
        _gameOveText.enabled = true;
        yield return new WaitForSeconds(3f);
        _gameOveText.enabled = false;
        LoadCsv._stageNum = LoadCsv._stageNum - 1;
        _gameOver = false;
        StartCoroutine(NextStage());
        yield break;
    }

    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(0.5f);
        _audioController.GetComponent<AudioController>().ClearSePlay();
        _resultSprite.enabled = true;
        yield return new WaitForSeconds(3f);
        _resultSprite.enabled = false;
        StartCoroutine(NextStage());
        yield break;
    }

    private IEnumerator NextStage()
    {
        StageReset.StageDestroy();

        if (StageOrder.StageQuantity <= LoadCsv._stageNum)
        {
            print("ok");
            GameStatus.SceneStatusReactivePropety.Value = SceneStatusEnum.Reset;
            LoadCsv._stageNum = 0;
        }
        else
        {
            SceneManager.Instance.CallSceneChange(SceneStatusEnum.Game);
        }

        yield break;
    }
}
