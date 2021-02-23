using UnityEngine;

public class StageCreate : SingletonMonoBehaviour<StageCreate>
{
    private int[,] _array = default;

    private GameObject _bubblePrefab = default;

    //prefab取得用（以下6つ）
    private GameObject _redBubble = default;
    private GameObject _blueBubble = default;
    private GameObject _yellowBubble = default;
    private GameObject _greenBubble = default;
    private GameObject _purpleBubble = default;
    private GameObject _basis = default;

    private void Start()
    {
        _array = ArrayData.Array;

        //prefabを読み込み
        _redBubble = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.RED_BUBBLE_NAME);
        _blueBubble = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.BLUE_BUBBLE_NAME);
        _yellowBubble = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.YELLOW_BUBBLE_NAME);
        _greenBubble = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.GREEN_BUBBLE_NAME);
        _purpleBubble = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.PURPLE_BUBBLE_NAME);
        _basis = (GameObject)Resources.Load(Pass.PREFAB + "/" + Pass.BASIS_NAME);
    }

    public void SetStage()
    {
        //基盤を生成
        SetBasis();

        for (int i = 1; i < _array.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < _array.GetLength(1) - 1; j++)
            {
                if (i % 2 != 0 && j == _array.GetLength(1) - 1)
                {
                    //この番地は使わない
                }
                else
                {
                    BubbleSet(_array[i, j], i, j);
                }
            }
        }

        //生成後ゲームステータス変更
        GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.GameStart;
    }

    private void BubbleSet(int value, int i, int j)
    {
        _bubblePrefab = default;
        switch (value)
        {
            case ArrayManipulation.RED_BUBBLE:
                _bubblePrefab = _redBubble;
                break;
            case ArrayManipulation.BLUE_BUBBLE:
                _bubblePrefab = _blueBubble;
                break;
            case ArrayManipulation.YELLOW_BUBBLE:
                _bubblePrefab = _yellowBubble;
                break;
            case ArrayManipulation.GREEN_BUBBLE:
                _bubblePrefab = _greenBubble;
                break;
            case ArrayManipulation.PURPLE_BUBBLE:
                _bubblePrefab = _purpleBubble;
                break;
        }

        if (_bubblePrefab != null)
        {
            //バブルオブジェクト生成
            GameObject bubbleObj = Instantiate(_bubblePrefab, PositonCalculation(i, j), Quaternion.identity);

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

    /// <summary>
    /// 基盤部分の生成
    /// </summary>
    private void SetBasis()
    {
        for (int j = 0; j < _array.GetLength(1); j++)  
        {
            if(_array[0,j]== ArrayManipulation.BASIS)
            {
                GameObject basisObj = Instantiate(_basis, new Vector3(transform.position.x + j * ArrayManipulation.BUBBLE_SIZE, transform.position.y), Quaternion.identity);

                //基盤に配列位置を持たせる
                basisObj.GetComponent<BubblePosition>().SetBubblePosition(0, j);
            }
        }
    }
}
