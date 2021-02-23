using UnityEngine;

public class AudioController : SingletonMonoBehaviour<AudioController>
{
    private AudioSource[] _audio = default;

    private AudioClip _shotSe = default;

    private AudioClip _destroySe = default;

    private AudioClip _clearSe = default;

    private AudioClip _gameOverSe = default;

    private AudioClip _clickSe = default;

    private AudioClip _gameBgm = default;

    private AudioClip _op = default;

    private void Start()
    {
        _audio = GetComponents<AudioSource>();

        _shotSe= (AudioClip)Resources.Load(Pass.AUDIO +"/"+ Pass.SHOT_PASS);

        _destroySe= (AudioClip)Resources.Load(Pass.AUDIO + "/" + Pass.DESTROY_PASS);

        _clearSe= (AudioClip)Resources.Load(Pass.AUDIO + "/" + Pass.CLEAR_PASS);

        _gameOverSe = (AudioClip)Resources.Load(Pass.AUDIO + "/" + Pass.GAMEOVER_PASS);

        _clickSe=(AudioClip)Resources.Load(Pass.AUDIO + "/" + Pass.CLICK_PASS);

        _gameBgm= (AudioClip)Resources.Load(Pass.AUDIO + "/" + Pass.GAME_BGM_PASS);

        _op= (AudioClip)Resources.Load(Pass.AUDIO + "/" + Pass.OP);
    }

    public void BgmPlay()
    {
        _audio[0].clip = _gameBgm;
        _audio[0].loop = true;
        _audio[0].Play();
    }
    public void OpPlay()
    {
        _audio[0].clip = _op;
        _audio[0].loop = false;
        _audio[0].Play();
    }

    public void ShotSePlay()
    {
        _audio[1].clip = _shotSe;
        _audio[1].Play();
    }

    public void DestroySePlay()
    {
        _audio[1].clip = _destroySe;
        _audio[1].Play();
    }

    public void ClearSePlay()
    {
        _audio[0].Stop();
        _audio[1].clip = _clearSe;
        _audio[1].Play();
    }

    public void GameOverSePlay()
    {
        _audio[0].Stop();
        _audio[1].clip = _gameOverSe;
        _audio[1].Play();
    }

    public void ClickSePlay()
    {
        _audio[0].Stop();
        _audio[1].clip = _clickSe;
        _audio[1].Play();
    }
}
