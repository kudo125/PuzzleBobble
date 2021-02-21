using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 盤面のオブジェクトを消去
/// </summary>
public class DestroyObjects : SingletonMonoBehaviour<DestroyObjects>
{
    /// <summary>
    /// 代入用配列
    /// </summary>
    private int[,] array = default;

    private void Start()
    {
        array = ArrayData.Array;
    }

    public void BubbleDestroy()
    {
        for(int i=0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] > ArrayManipulation.DES_VALUE)
                {
                    ArrayData.GameObjectsArray[i, j].GetComponent<BubbleDestroyEfect>().DestroyEfect();

                    array[i, j] = 0;
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

        print(i + "  " + j);
        print(ArrayData.GameObjectsArray[i, j]);
        ArrayData.GameObjectsArray[i, j].GetComponent<BubbleDestroyEfect>().Drop();

        array[i, j] = default;
    }
}
