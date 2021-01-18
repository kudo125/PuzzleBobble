using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource[] audio = default;

    private AudioClip shotSE = default;

    private AudioClip destroySE = default;

    private AudioClip clearSE = default;

    const string pass = "Audio/";

    const string shotPass="shotSE";

    const string destroyPass = "destroySE";

    const string clearPass = "clearSE";

    private void Start()
    {
        audio = GetComponents<AudioSource>();

        shotSE= (AudioClip)Resources.Load(pass + shotPass);

        destroySE= (AudioClip)Resources.Load(pass + destroyPass);

        clearSE= (AudioClip)Resources.Load(pass + clearPass);

    }

    public void shotSEPlay()
    {
        audio[1].clip = shotSE;
        audio[1].Play();
    }

    public void destroySEPlay()
    {
        audio[1].clip = destroySE;
        audio[1].Play();
    }

    public void ClearSE()
    {
        audio[0].Stop();
        audio[1].clip = clearSE;
        audio[1].Play();
    }

    public void GameOverSE()
    {
       
    }

}
