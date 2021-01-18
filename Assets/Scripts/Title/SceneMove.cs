using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    const string menuScene = "MenuScene";

    private AudioSource titleAudio = default;

    private bool once = default;

    private void Start()
    {
        titleAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            once = true;

            titleAudio.Play();

            StartCoroutine(SceneChange());
        }
    }

    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(menuScene);

        yield break;
    }
}
