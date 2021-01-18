using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject audioController = default;

    private GameObject resultObj = default;

    private GameObject gameOverObj = default;

    private GameObject cannon = default;

    /// <summary>
    /// みどりのドラゴン
    /// </summary>
    private GameObject greenDragon = default;

    private Animator greenDragonAnim = default;

    private BubbleShot bubbleShot = default;

    private NextBubble nextBubble = default;

    private StageSet stageSet = default;

    const string cannonTag = "Cannon";

    const string greenDragonTag = "Green";

    const string greenDragonAnimationTrigger = "move";

    const string resultTag = "Clear";

    const string audioTag = "Audio";

    const string gameOverTag = "GameOver";

    const string titleScene = "TitleScene";

    private SpriteRenderer resultSprite = default;

    private Text gameOveText = default;

    private bool gameOver = default;

    public void GameStart()
    {
        cannon = GameObject.FindWithTag(cannonTag);
        greenDragon = GameObject.FindWithTag(greenDragonTag);
        resultObj = GameObject.FindWithTag(resultTag);
        gameOverObj = GameObject.FindWithTag(gameOverTag);
        audioController = GameObject.FindWithTag(audioTag);
        resultSprite = resultObj.GetComponent<SpriteRenderer>();
        gameOveText = gameOverObj.GetComponent<Text>();
        greenDragonAnim = greenDragon.GetComponent<Animator>();
        nextBubble = cannon.GetComponent<NextBubble>();
        stageSet = GetComponent<StageSet>();
        bubbleShot = cannon.GetComponent<BubbleShot>();

        stageSet.LoadStage();
        nextBubble.NextBubbleSet();
        nextBubble.SetShotBubble();

    }

    public void ShotEnd()
    {
        StartCoroutine(BubbleReload());
    }

    private void ShotReady()
    {
        bubbleShot.ShotReadyOn();
    }

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
        else
        {
            ShotReady();
        }
    }

    public void GameEnd()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        audioController.GetComponent<AudioController>().GameOverSE();
        gameOveText.enabled = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(titleScene);
        yield break;
    }

    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(0.5f);
        audioController.GetComponent<AudioController>().ClearSE();
        resultSprite.enabled = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(titleScene);
        yield break;
    }

    private IEnumerator BubbleReload()
    {
        greenDragonAnim.SetTrigger(greenDragonAnimationTrigger);
        yield return new WaitForSeconds(0.3f);
        nextBubble.SetShotBubble();
        yield break;
    }
}
