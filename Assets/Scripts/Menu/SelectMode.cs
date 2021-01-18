using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour
{
    const string gameScene = "GameScene";

    private AudioSource selectAudio = default;

    private bool once = default;

    private void Start()
    {
        selectAudio = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& !once||Input.GetKeyDown(KeyCode.Joystick1Button0) && !once)
        {
            once = true;

            selectAudio.Play();

            StartCoroutine(SceneChange());
        }
    }

    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(gameScene);

        yield break;
    }
}
