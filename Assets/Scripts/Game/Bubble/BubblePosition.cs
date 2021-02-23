using UnityEngine;

public class BubblePosition : MonoBehaviour
{
    private int _bubbleArrayI = default;

    private int _bubbleArrayJ = default;

    private BubbleValue _bubbleValue = default;

    public void SetBubblePosition(int i, int j)
    {
        _bubbleValue = GetComponent<BubbleValue>();

        _bubbleArrayI = i;
        _bubbleArrayJ = j;

        ArrayData.Array[i, j] = _bubbleValue.GetBubbleValue();

        //ゲームオブジェクト配列に格納
        ArrayData.GameObjectsArray[i, j] = gameObject;

        ArrayData.InstalledBubble[0] = i;
        ArrayData.InstalledBubble[1] = j;


    }

    public int GetBubblePositionI()
    {
        return _bubbleArrayI;
    }

    public int GetBubblePositionJ()
    {
        return _bubbleArrayJ;
    }
}
