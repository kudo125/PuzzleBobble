using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShot : MonoBehaviour
{
    private GameObject gameManager = default;

    private GameObject audioController = default;

    private GameController gameController = default;

    private GameObject bubblePrfb = default;

    private Rigidbody bubbleRig = default;

    private bool ShotReady = default;

    const float bubbleSpeed = 350f;

    const string gameManagerTag = "GameManager";

    const string inputTag = "Input";

    const string audioTag = "Audio";

    private void Start()
    {
        gameManager = GameObject.FindWithTag(gameManagerTag);

        audioController = GameObject.FindWithTag(audioTag);

        gameController = gameManager.GetComponent<GameController>();

        ShotReadyOn();

    }

    public void SetPrefab(GameObject bubble)
    {
        bubblePrfb = bubble;
        GameObject bubbleObj = (GameObject)Instantiate(bubblePrfb, transform.position, Quaternion.identity);
        bubbleRig = bubbleObj.GetComponent<Rigidbody>();
    }

    public void Shot()
    {
        float rad = -transform.localEulerAngles.z* Mathf.Deg2Rad;

        float addforceX = Mathf.Sin(rad);
        float addforceY = Mathf.Cos(rad);
        Vector3 shotVector = new Vector3(addforceX, addforceY,0);

        bubbleRig.AddForce(shotVector*bubbleSpeed);

        audioController.GetComponent<AudioController>().shotSEPlay();
        gameController.ShotEnd();
    }

    public void ShotReadyOn()
    {
        ShotReady = true;
    }
}
