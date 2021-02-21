using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    private GameObject[] sceneObj = default;

    private const int TITLE_NOM   = 0;
    private const int MENU_NOM    = 1;
    private const int GAME_NOM    = 2;

    private void Start()
    {
        sceneObj = new GameObject[transform.childCount];

        //子オブジェクトをすべて取得
        for (int i = 0; i < transform.childCount; i++)
        {
            sceneObj[i] = transform.GetChild(i).gameObject;
        }
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

        //シーンステータス変更
        GameStatus.SceneStatusReactivePropety.Value=scene;

        //シーンオブジェクトをすべてOFF
        for (int i = 0; i < sceneObj.Length; i++)
        {
            sceneObj[i].SetActive(false);
        }

        yield return new WaitForSeconds(0.5f);

        if ((int)scene == TITLE_NOM)
        {
            //タイトルシーンに変更
            sceneObj[TITLE_NOM].SetActive(true);
        }
        else if ((int)scene == MENU_NOM)
        {
            //メニューシーンに変更
            sceneObj[MENU_NOM].SetActive(true);
        }
        else if ((int)scene == GAME_NOM)
        {
            //ゲームシーンに変更
            sceneObj[GAME_NOM].SetActive(true);
        }
        yield break;
    }
}
