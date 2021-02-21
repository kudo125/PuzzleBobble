using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBubble : SingletonMonoBehaviour<NextBubble>
{
    private int[,] array = default;

    private GameObject bubblePrfb = default;

    private Transform nextTransform = default;

    private GameObject NextBubbleObj=default;

    override protected void Awake()
    {
        nextTransform = GameObject.FindWithTag("Next").GetComponent<Transform>();

        array = ArrayData.Array;
    }

    /// <summary>
    /// ステージ上にあるバブルの中からランダムで生成
    /// </summary>
    /// <returns></returns>
    private GameObject LoadBubble()
    {
        bool red = default;
        bool blue = default;
        bool green = default;
        bool purple = default;
        bool yellow = default;

        for (int i = 0; i < array.GetLength(0); i++) 
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                int bubbleValue = array[i, j];

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
                    yellow = true;
                }
                else if (bubbleValue == 4)
                {
                    green = true;
                }
                else if (bubbleValue == 5)
                {
                    purple = true;
                }
            }
        }

        string[] NextBubbles = new string[5];

        for(int i = 0; i < NextBubbles.GetLength(0); i++)
        {
            NextBubbles[i] = "none";
        }

        if (red)
        {
            NextBubbles[0] = Pass.RED_BUBBLE_NAME;
        }
        if (blue)
        {
            NextBubbles[1] = Pass.BLUE_BUBBLE_NAME;
        }
        if (yellow)
        {
            NextBubbles[2] = Pass.YELLOW_BUBBLE_NAME;
        }
        if (green)
        {
            NextBubbles[3] = Pass.GREEN_BUBBLE_NAME;
        }
        if (purple)
        {
            NextBubbles[4] = Pass.PURPLE_BUBBLE_NAME;
        }

        //NextBubblesが空かどうか
        int isNull = default;

        for(int i = 0; i < NextBubbles.Length; i++)
        {
            if (NextBubbles[i] == null)
            {
                isNull++;
            }
        }

        string bubblePass = NextBubbles[Random.Range(0, 5)];

        if (isNull < 5)
        {
            for (int i = 0; bubblePass == "none"; i++)
            {
                bubblePass = NextBubbles[Random.Range(0, 5)];
            }
        }
        
        bubblePrfb = (GameObject)Resources.Load(Pass.PREFAB + "/" + bubblePass);
        
        return bubblePrfb;
    }

    public void NextBubbleSet()
    {
        NextBubbleObj = Instantiate(LoadBubble(), nextTransform.position, Quaternion.identity); 
    }

    public void SetShotBubble()
    {
        BubbleShot.Instance.SetPrefab(NextBubbleObj);
        Destroy(NextBubbleObj);
        NextBubbleSet();
    }
}
