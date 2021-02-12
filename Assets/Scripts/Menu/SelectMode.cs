using UnityEngine;

public class SelectMode : MonoBehaviour
{
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
        }
    }
}
