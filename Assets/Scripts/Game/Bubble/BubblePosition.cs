using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePosition : MonoBehaviour
{
    private GameObject gameManager = default;

    [SerializeField]
    private int bubbleArrayI = default;

    [SerializeField]
    private int bubbleArrayJ = default;

    private BubbleValue bubbleValue = default;

    private ArrayManager arrayManager = default;

    private GameController gameController = default;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");

        bubbleValue = GetComponent<BubbleValue>();

        arrayManager = gameManager.GetComponent<ArrayManager>();

        gameController = gameManager.GetComponent<GameController>();
    }

    public void SetBubblePosition(int i,int j)
    {
        bubbleArrayI = i;
        bubbleArrayJ = j;

        if (i > 11)
        {
            gameController.GameEnd();
        }
        else
        {
            arrayManager.SetValue(bubbleArrayI, bubbleArrayJ, bubbleValue.GetBubbleValue());
        }
    }

    public int GetBubblePositionI()
    {
        return bubbleArrayI;
    }

    public int GetBubblePositionJ()
    {
        return bubbleArrayJ;
    }
}
