using UnityEngine;

public class BubbleShot : SingletonMonoBehaviour<BubbleShot>
{
    private GameObject _audioController = default;

    private GameObject _bubblePrfb = default;

    private Rigidbody _bubbleRig = default;

    private const float _bubbleSpeed = 350f;

    private void Start()
    {
        _audioController = GameObject.FindWithTag(Tags.AUDIO);
    }

    public void SetPrefab(GameObject bubble)
    {
        _bubblePrfb = bubble;
        GameObject bubbleObj = (GameObject)Instantiate(_bubblePrfb, transform.position, Quaternion.identity);
        _bubbleRig = bubbleObj.GetComponent<Rigidbody>();
    }

    public void Shot()
    {
        float rad = -transform.localEulerAngles.z* Mathf.Deg2Rad;

        float addforceX = Mathf.Sin(rad);
        float addforceY = Mathf.Cos(rad);
        Vector3 shotVector = new Vector3(addforceX, addforceY,0);

        _bubbleRig.AddForce(shotVector*_bubbleSpeed);

        _audioController.GetComponent<AudioController>().ShotSePlay();

        GameStatus.PlayerStatusReactiveProperty.Value = PlayerStatusEnum.SetBubble;
    }
}
