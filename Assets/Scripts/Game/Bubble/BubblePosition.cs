using UnityEngine;

public class BubblePosition : MonoBehaviour
{
    [SerializeField]
    private int bubbleArrayI = default;

    [SerializeField]
    private int bubbleArrayJ = default;

    private BubbleValue bubbleValue = default;

    /// <summary>
    /// 配列のゲームオーバーの境界位置
    /// </summary>
    private const int UPPER_LIMIT = 11;

    public void SetBubblePosition(int i,int j)
    {
        bubbleValue = GetComponent<BubbleValue>();

        bubbleArrayI = i;
        bubbleArrayJ = j;

        if (i > UPPER_LIMIT)
        {
            GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.GameOver;
        }
        else
        {
            ArrayData.Array[i, j] = bubbleValue.GetBubbleValue();

            //ゲームオブジェクト配列に格納
            ArrayData.GameObjectsArray[i, j] = gameObject;

            ArrayData.InstalledBubble[0] = i;
            ArrayData.InstalledBubble[1] = j;
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
