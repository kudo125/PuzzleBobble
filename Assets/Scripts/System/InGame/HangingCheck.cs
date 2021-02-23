/// <summary>
///ぶら下がり判定クラス 
/// </summary>
public class HangingCheck : SingletonMonoBehaviour<HangingCheck>
{
    /// <summary>
    /// 代入用配列
    /// </summary>
    private int[,] _array = new int[13, 10];

    /// <summary>
    /// 隣接しているかどうか判定用
    /// </summary>
    private bool _adjacent = default;

    /// <summary>
    /// 対象オブジェクトを探す
    /// </summary>
    public void TargetObjectSearch()
    {
        for(int i = 0; i < ArrayData.Array.GetLength(0); i++)
        {
            for(int j = 0; j < ArrayData.Array.GetLength(1); j++)
            {
                _array[i, j] = ArrayData.Array[i, j];
            }
        }

        //盤面上の上から2番目のバブルから順に確認
        for (int j = 1; j < _array.GetLength(1) - 1; j++)
        {
            if (_array[1, j] > 0)
            {
                _array[1, j] = ArrayManipulation.DES_VALUE;
                HangingCheckUp();

            }

        }

        CallNotAdjacentDestroy();

        //すべて終わったらゲームステータス変更
        GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.ArrayCheck;
    }

    /// <summary>
    /// ぶら下がり判定
    /// </summary>
    private void HangingCheckUp()
    {
        for (int i = 2; i<_array.GetLength(0)-1; i++)
        {
            for(int j = 1; j < _array.GetLength(1)-1; j++)
            {
                _adjacent = default;

                //偶数の時
                if (i % 2 == 0 && _array[i, j] > 0)
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
                else if(_array[i, j] > 0)
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
                if (_adjacent)
                {
                    //定数に置き換え
                    _array[i, j] = ArrayManipulation.DES_VALUE;
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
        if (ArrayManipulation.DES_VALUE==_array[nextToI, nextToJ])
        {
            _adjacent = true;
        }
    }

    /// <summary>
    /// NotAdjacentDestroy()呼び出し用
    /// </summary>
    private void CallNotAdjacentDestroy()
    {
        for(int i = 0; i < _array.GetLength(0); i++)
        {
            for(int j = 0; j < _array.GetLength(1); j++)
            {
                if (_array[i, j] < ArrayManipulation.DES_VALUE && _array[i, j] > 0)
                {
                    DestroyObjects.Instance.NotAdjacentDestroy(i, j);
                }
            }
        }
    }
}
