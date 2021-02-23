using System.Collections;
using UnityEngine;
using UniRx;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    private GameObject[] _sceneObjs = default;

    private const int TITLE_NOM   = 0;
    private const int MENU_NOM    = 1;
    private const int GAME_NOM    = 2;

    private void Start()
    {
        _sceneObjs = new GameObject[transform.childCount];

        //子オブジェクトをすべて取得
        for (int i = 0; i < transform.childCount; i++)
        {
            _sceneObjs[i] = transform.GetChild(i).gameObject;
        }

        //ゲームステータスがResetの時
        GameStatus.SceneStatusReactivePropety
            .DistinctUntilChanged()
            .Where(status => status == SceneStatusEnum.Reset)
            .Subscribe(_ => CallSceneChange(SceneStatusEnum.Title))
            .AddTo(this);
    }

    /// <summary>
    /// SceneChenge呼び出し用
    /// </summary>
    /// <param name="scene"></param>
    public void CallSceneChange( SceneStatusEnum scene)
    {
        StartCoroutine(SceneChange(scene));
    }

    private IEnumerator SceneChange(SceneStatusEnum scene)
    {
        yield return new WaitForSeconds(0.2f);

        print("scene " + scene);

        //シーンステータス変更
        GameStatus.SceneStatusReactivePropety.Value=scene;

        //シーンオブジェクトをすべてOFF
        for (int i = 0; i < _sceneObjs.Length; i++)
        {
            _sceneObjs[i].SetActive(false);
        }

        yield return new WaitForSeconds(0.5f);

        if ((int)scene == TITLE_NOM)
        {
            //タイトルシーンに変更
            _sceneObjs[TITLE_NOM].SetActive(true);
            AudioController.Instance.OpPlay();
        }
        else if ((int)scene == MENU_NOM)
        {
            //メニューシーンに変更
            _sceneObjs[MENU_NOM].SetActive(true);
        }
        else if ((int)scene == GAME_NOM)
        {
            //ゲームシーンに変更
            _sceneObjs[GAME_NOM].SetActive(true);
            GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.None;
        }
        yield break;
    }
}
