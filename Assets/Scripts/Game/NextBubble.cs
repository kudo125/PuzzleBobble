using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBubble : MonoBehaviour
{
    const string pass = "Prefabs/";

    const string redPass = "BubbleRed";

    const string bluePass = "BubbleBlue";

    const string greenPass = "BubbleGreen";

    const string purplePass = "BubblePurple";

    const string yellowPass = "BubbleYellow";

    private GameObject bubblePrfb;

    private Transform nextTransform = default;

    private GameObject cannon = default;

    private GameObject NextBubbleObj=default;

    private BubbleShot bubbleShot = default;

    private void Awake()
    {
        nextTransform = GameObject.FindWithTag("Next").GetComponent<Transform>();

        cannon = GameObject.FindWithTag("Cannon");
        bubbleShot = cannon.GetComponent<BubbleShot>();
    }

    private GameObject LoadBubble()
    {
        bool red = default;
        bool blue = default;
        bool green = default;
        bool purple = default;
        bool yellow = default;

        GameObject[] bubbleObjs = GameObject.FindGameObjectsWithTag("Placed");

        for(int i = 0; i<bubbleObjs.GetLength(0); i++)
        {

            int bubbleValue = bubbleObjs[i].GetComponent<BubbleValue>().GetBubbleValue();

            if (bubbleValue == 1)
            {
                red = true;
            }
            else if (bubbleValue == 2)
            {
                blue = true;
            }
            else if (bubbleValue == 3)
            {
                green = true;
            }
            else if (bubbleValue == 4)
            {
                purple = true;
            }
            else if (bubbleValue == 5)
            {
                yellow = true;
            }
             
        }

        string[] NextBubbles = new string[5];

        for(int i = 0; i < NextBubbles.GetLength(0); i++)
        {
            NextBubbles[i] = "none";
        }

        if (red==true)
        {
            NextBubbles[0] = redPass;
        }
        if (blue == true)
        {
            NextBubbles[1] = bluePass;
        }
        if (green == true)
        {
            NextBubbles[2] = greenPass;
        }
        if (purple == true)
        {
            NextBubbles[3] = purplePass;
        }
        if (yellow == true)
        {
            NextBubbles[4] = yellowPass;
        }

        string bubblePass = NextBubbles[Random.Range(0, 5)];

        while (bubblePass == "none")
        {
            bubblePass = NextBubbles[Random.Range(0, 5)];
        }

        bubblePrfb = (GameObject)Resources.Load(pass + bubblePass);

        return bubblePrfb;
    }

    public void NextBubbleSet()
    {
        NextBubbleObj = (GameObject)Instantiate(LoadBubble(), nextTransform.position, Quaternion.identity); 
    }

    public void SetShotBubble()
    {
        bubbleShot.SetPrefab(NextBubbleObj);
        Destroy(NextBubbleObj);
        NextBubbleSet();
    }
}
