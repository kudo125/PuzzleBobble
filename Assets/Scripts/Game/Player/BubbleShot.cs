using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShot : SingletonMonoBehaviour<BubbleShot>
{
    private GameObject audioController = default;

    private GameObject bubblePrfb = default;

    private Rigidbody bubbleRig = default;

    private const float bubbleSpeed = 350f;

    private void Start()
    {
        audioController = GameObject.FindWithTag(Tags.AUDIO);
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

        GameStatus.PlayerStatusReactiveProperty.Value = PlayerStatusEnum.SetBubble;
    }
}
