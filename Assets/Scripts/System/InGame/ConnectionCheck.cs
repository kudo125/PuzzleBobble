public class ConnectionCheck : SingletonMonoBehaviour<ConnectionCheck>
{
    /// <summary>
    /// 代入用配列
    /// </summary>
    private int[,] array = default;

    /// <summary>
    /// 隣接バブルの番地情報格納用配列I
    /// </summary>
    private int[] adjacentI = new int[130];

    /// <summary>
    /// 隣接バブルの番地情報格納用配列J
    /// </summary>
    private int[] adjacentJ = new int[130];

    /// <summary>
    /// 消えるまでのつながり上限値
    /// </summary>
    private const int DES_LINE = 2;

    /// <summary>
    /// つながっているバブル数
    /// </summary>
    private int ConnectCount = default;

    private int adjPointer = default;

    /// <summary>
    /// 基準値
    /// </summary>
    private int criteria = default;

    private void Start()
    {
        array = ArrayData.Array;
    }

    /// <summary>
    ///　隣接するバブルがなくなるまで再起処理をする
    /// </summary>
    public void AdjacentCheck()
    {
        //配列の初期化
        adjacentI = Initialize.InitializeOneDimensionalArray(adjacentI);
        adjacentJ = Initialize.InitializeOneDimensionalArray(adjacentJ);

        adjacentI[0] = ArrayData.InstalledBubble[0];
        adjacentJ[0] = ArrayData.InstalledBubble[1];

        criteria = array[adjacentI[0], adjacentJ[0]];

        //カウントの初期化
        ConnectCount = 0;

        //ポインターの初期化
        adjPointer = 0;

        for (int i = 0; adjacentI[i] > 0; i++)
        {
            int adjI = adjacentI[i];
            int adjJ = adjacentJ[i];

            //偶数の時
            if (adjI % 2 == 0)
            {
                //左上を見る
                Check(adjI, adjJ, adjI - 1, adjJ);
                //右上を見る
                Check(adjI, adjJ, adjI - 1, adjJ + 1);
                //左を見る
                Check(adjI, adjJ, adjI, adjJ - 1);
                //右を見る
                Check(adjI, adjJ, adjI, adjJ + 1);
                //左下を見る
                Check(adjI, adjJ, adjI + 1, adjJ);
                //右下を見る
                Check(adjI, adjJ, adjI + 1, adjJ + 1);
            }
            //奇数の時
            else
            {
                //左上を見る
                Check(adjI, adjJ, adjI - 1, adjJ - 1);
                //右上を見る
                Check(adjI, adjJ, adjI - 1, adjJ);
                //左を見る
                Check(adjI, adjJ, adjI, adjJ - 1);
                //右を見る
                Check(adjI, adjJ, adjI, adjJ + 1);
                //左下を見る
                Check(adjI, adjJ, adjI + 1, adjJ - 1);
                //右下を見る
                Check(adjI, adjJ, adjI + 1, adjJ);
            }
        }

        //つながりバブルが一定数を超えるとゲームステータスを変更
        if (ConnectCount >= DES_LINE)
        {
            GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.Destroy;
        }
        //消すバブルがない時ゲームステータスとプレイヤーステータス変更
        else
        {
            //配列の情報を元の状態に戻す
            Undo.UndoArray();

            GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.Idle;
        }
    }

    /// <summary>
    /// 隣の値を比較
    /// </summary>
    /// <param name="i">元の番地I</param>
    /// <param name="j">元の番地J</param>
    /// <param name="nextToI">先の番地I</param>
    /// <param name="nextToJ">先の番地J</param>
    private void Check(int i, int j, int nextToI, int nextToJ)
    {
        if (criteria == array[nextToI, nextToJ] && array[nextToI, nextToJ] < ArrayManipulation.DES_VALUE)
        {
            //配列の値に定数をプラスした値に置き換える
            array[i, j] = criteria + ArrayManipulation.DES_VALUE;
            array[nextToI, nextToJ] = criteria + ArrayManipulation.DES_VALUE;

            ConnectCount++;

            adjPointer++;
            adjacentI[adjPointer] = nextToI;
            adjacentJ[adjPointer] = nextToJ;
        }
        if (criteria + ArrayManipulation.DES_VALUE == array[nextToI, nextToJ])
        {
            if(array[i,j]< ArrayManipulation.DES_VALUE)
            {
                //配列の値に定数をプラスする
                array[i, j] += ArrayManipulation.DES_VALUE;
            }
        }
    }
}
