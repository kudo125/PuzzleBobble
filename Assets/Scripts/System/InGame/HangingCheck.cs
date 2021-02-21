using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingCheck : SingletonMonoBehaviour<HangingCheck>
{
    /// <summary>
    /// 代入用配列
    /// </summary>
    private int[,] array = new int[13, 10];

    /// <summary>
    /// 隣接しているかどうか判定用
    /// </summary>
    private bool adjacent = default;

    /// <summary>
    /// 対象オブジェクトを探す
    /// </summary>
    public void TargetObjectSearch()
    {
        for(int i = 0; i < ArrayData.Array.GetLength(0); i++)
        {
            for(int j = 0; j < ArrayData.Array.GetLength(1); j++)
            {
                array[i, j] = ArrayData.Array[i, j];
            }
        }

        Debug.DebagArray(ArrayData.Array);

        //盤面上の上から2番目のバブルから順に確認
        for (int j = 1; j < array.GetLength(1) - 1; j++)
        {
            if (array[1, j] > 0)
            {
                array[1, j] = ArrayManipulation.DES_VALUE;
                HangingCheckUp();

            }

        }

        CallNotAdjacentDestroy();

        //すべて終わったらゲームステータス変更
        GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.Idle;
    }

    /// <summary>
    /// ぶら下がり判定
    /// </summary>
    private void HangingCheckUp()
    {
        for (int i = 2; i<array.GetLength(0)-1; i++)
        {
            for(int j = 1; j < array.GetLength(1)-1; j++)
            {
                adjacent = default;

                //偶数の時
                if (i % 2 == 0 && array[i, j] > 0)
                {
                    //左上を見る
                    Check(i - 1, j);
                    //右上を見る
                    Check(i - 1, j + 1);
                    //左を見る
                    Check(i, j - 1);
                    //右を見る
                    Check(i, j + 1);
                    //左下を見る
                    Check(i + 1, j);
                    //右下を見る
                    Check(i + 1, j + 1);
                }
                //奇数の時
                else if(array[i, j] > 0)
                {
                    //左上を見る
                    Check(i - 1, j - 1);
                    //右上を見る
                    Check(i - 1, j);
                    //左を見る
                    Check(i, j - 1);
                    //右を見る
                    Check(i, j + 1);
                    //左下を見る
                    Check(i + 1, j - 1);
                    //右下を見る
                    Check(i + 1, j);
                }
                if (adjacent)
                {
                    //定数に置き換え
                    array[i, j] = ArrayManipulation.DES_VALUE;
                }
            }
        }
    }
    /// <summary>
    /// 隣接しているか確認
    /// </summary>
    /// <param name="nextToI">先の番地I</param>
    /// <param name="nextToJ">先の番地J</param>
    private void Check(int nextToI, int nextToJ)
    {
        //隣接バブルがある場合
        if (ArrayManipulation.DES_VALUE==array[nextToI, nextToJ])
        {
            adjacent = true;
        }
    }

    /// <summary>
    /// NotAdjacentDestroy()呼び出し用
    /// </summary>
    private void CallNotAdjacentDestroy()
    {
        Debug.DebagArray(array);
        for(int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] < ArrayManipulation.DES_VALUE && array[i, j] > 0)
                {
                    DestroyObjects.Instance.NotAdjacentDestroy(i, j);
                }
            }
        }
    }
}
