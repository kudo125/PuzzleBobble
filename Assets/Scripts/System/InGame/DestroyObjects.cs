/// <summary>
/// 盤面のオブジェクトを消去
/// </summary>
public class DestroyObjects : SingletonMonoBehaviour<DestroyObjects>
{
    /// <summary>
    /// 代入用配列
    /// </summary>
    private int[,] _array = default;

    private void Start()
    {
        _array = ArrayData.Array;
    }

    public void BubbleDestroy()
    {
        AudioController.Instance.DestroySePlay();
        for(int i=0; i < _array.GetLength(0); i++)
        {
            for(int j = 0; j < _array.GetLength(1); j++)
            {
                if (_array[i, j] > ArrayManipulation.DES_VALUE)
                {
                    ArrayData.GameObjectsArray[i, j].GetComponent<BubbleDestroyEfect>().DestroyEfect();

                    _array[i, j] = 0;
                }
            }
        }
        //ゲームステータスを変更
        GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.Hanging;
    }

    /// <summary>
    /// どこにもつながっていないバブルを消す
    /// </summary>
    public void NotAdjacentDestroy(int i, int j)
    {
        ArrayData.GameObjectsArray[i, j].GetComponent<BubbleDestroyEfect>().Drop();

        _array[i, j] = default;
    }
}
