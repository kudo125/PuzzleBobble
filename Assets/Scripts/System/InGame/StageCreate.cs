using UnityEngine;

public class StageCreate : SingletonMonoBehaviour<StageCreate>
{
    private GameObject[,] gameObjectsArray = default;

    private int[,] array = default;

    private GameObject bubblePrefab = default;

    //prefab取得用（以下6つ）
    private GameObject redBubble = default;
    private GameObject blueBubble = default;
    private GameObject yellowBubble = default;
    private GameObject greenBubble = default;
    private GameObject purpleBubble = default;
    private GameObject basis = default;

    private void Start()
    {
        gameObjectsArray = ArrayData.GameObjectsArray;
        array = ArrayData.Array;

        //prefabを読み込み
        redBubble = Resources.Load<GameObject>(Pass.PREFAB + "/" + Pass.RED_BUBBLE_NAME);
        blueBubble = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.BLUE_BUBBLE_NAME);
        yellowBubble = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.YELLOW_BUBBLE_NAME);
        greenBubble = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.GREEN_BUBBLE_NAME);
        purpleBubble = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.PURPLE_BUBBLE_NAME);
        basis = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.BASIS_NAME);
    }

    public void SetStage()
    {
        for (int i = 1; i < array.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < array.GetLength(1) - 1; j++)
            {
                if (i % 2 != 0 && j == array.GetLength(1) - 1)
                {
                    //この番地は使わない
                }
                else
                {
                    BubbleSet(array[i, j], i, j);
                }
            }
        }

        //生成後ゲームステータス変更
        GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.GameStart;
    }

    private void BubbleSet(int value, int i, int j)
    {
        bubblePrefab = default;
        switch (value)
        {
            case ArrayManipulation.RED_BUBBLE:
                bubblePrefab = redBubble;
                break;
            case ArrayManipulation.BLUE_BUBBLE:
                bubblePrefab = blueBubble;
                break;
            case ArrayManipulation.YELLOW_BUBBLE:
                bubblePrefab = yellowBubble;
                break;
            case ArrayManipulation.GREEN_BUBBLE:
                bubblePrefab = greenBubble;
                break;
            case ArrayManipulation.PURPLE_BUBBLE:
                bubblePrefab = purpleBubble;
                break;
            case ArrayManipulation.BASIS:
                bubblePrefab = basis;
                break;
        }

        if (bubblePrefab != null)
        {
            //バブルオブジェクト生成
            GameObject bubbleObj = Instantiate(bubblePrefab, PositonCalculation(i, j), Quaternion.identity);

            //設置済みバブルにする
            bubbleObj.GetComponent<BubblePlaced>().Placed();
          
            //バブルに配列位置を持たせる
            bubbleObj.GetComponent<BubblePosition>().SetBubblePosition(i, j);
        }
    }

    private Vector3 PositonCalculation(int i, int j)
    {
        Vector3 bubblePosi = transform.position;

        if (i % 2 == 0)
        {
            bubblePosi = new Vector3(transform.position.x + j * ArrayManipulation.BUBBLE_SIZE,
                                             transform.position.y - (i *(ArrayManipulation.BUBBLE_SIZE * Mathf.Sqrt(3f) / 2)));
        }
        else if(i==1)
        {
            bubblePosi = new Vector3(transform.position.x + (j-1) * ArrayManipulation.BUBBLE_SIZE + ArrayManipulation.BUBBLE_SIZE / 2,//ここはあってる
                                             transform.position.y - (ArrayManipulation.BUBBLE_SIZE * Mathf.Sqrt(3f) / 2));
        }
        else
        {
            bubblePosi = new Vector3(transform.position.x + (j - 1) * ArrayManipulation.BUBBLE_SIZE + ArrayManipulation.BUBBLE_SIZE / 2,//ここはあってる
                                             transform.position.y - (i * (ArrayManipulation.BUBBLE_SIZE * Mathf.Sqrt(3f) / 2)));
        }

        return bubblePosi;
    }
}
