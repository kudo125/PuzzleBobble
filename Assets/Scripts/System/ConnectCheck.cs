using System.Collections;
using UnityEngine;

public class ConectCheck : MonoBehaviour
{
    /// <summary>
    /// 代入用配列
    /// </summary>
    private int[,] array = default;

    /// <summary>
    /// 隣接判定用配列
    /// </summary>
    private int[,] hangingArray = new int[13, 10];

    /// <summary>
    /// 隣接バブルの番地情報格納用配列I
    /// </summary>
    private int[] adjacentI = new int[130];

    /// <summary>
    /// 隣接バブルの番地情報格納用配列J
    /// </summary>
    private int[] adjacentJ = new int[130];

    /// <summary>
    /// 隣接バブルの番地情報格納用配列　の　番地情報
    /// </summary>
    private int adjacentCount = default;

    private void Start()
    {
        Array arraydata = new Array();

        array = arraydata.GetArray();
        
    }

    /// <summary>
    ///　隣接するバブルがなくなるまで再起処理をする
    /// </summary>
    private void AdjacentCheck(int i, int j)
    {
        adjacentI[0] = i;
        adjacentJ[0] = j;

        int destroyCount = default;

        int adjPosition = default; ;

        for (int adj = 0; adjacentI[adj] > -5; adj++)
        {
            if (adjacentI[adj] % 2 == 0)
            {
                //左上を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] - 1, adjacentJ[adj]] && array[adjacentI[adj] - 1, adjacentJ[adj]] < 10)
                {
                    adjacentCount++;
                    //消去バブルのチェックを入れる
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);

                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj] - 1;
                    adjacentJ[adjPosition] = adjacentJ[adj];
                }
                //右上を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] - 1, adjacentJ[adj] + 1] && array[adjacentI[adj] - 1, adjacentJ[adj] + 1] < 10)
                {
                    adjacentCount++;
                    //消去バブルのチェックを入れる
                    array[adjacentI[adj], adjacentJ[adj]] += -20; 
                    destroyCount++;

                    print(1);

                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj] - 1;
                    adjacentJ[adjPosition] = adjacentJ[adj] + 1;
                }
                //右を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj], adjacentJ[adj] + 1] && array[adjacentI[adj], adjacentJ[adj] + 1] < 10)
                {
                    adjacentCount++;
                    //消去バブルのチェックを入れる
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);


                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj];
                    adjacentJ[adjPosition] = adjacentJ[adj] + 1;
                }
                //右下を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] + 1, adjacentJ[adj] + 1] && array[adjacentI[adj] + 1, adjacentJ[adj] + 1] < 10)
                {
                    adjacentCount++;
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);

                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj] + 1;
                    adjacentJ[adjPosition] = adjacentJ[adj] + 1;
                }
                //左下を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] + 1, adjacentJ[adj]] && array[adjacentI[adj] + 1, adjacentJ[adj]] < 10)
                {
                    adjacentCount++;
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);

                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj] + 1;
                    adjacentJ[adjPosition] = adjacentJ[adj];
                }
                //左を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj], adjacentJ[adj] - 1] && array[adjacentI[adj], adjacentJ[adj] - 1] < 10)
                {
                    adjacentCount++;
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);


                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj];
                    adjacentJ[adjPosition] = adjacentJ[adj] - 1;
                }
            }
            else
            {
                //左上を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] - 1, adjacentJ[adj] - 1] && array[adjacentI[adj] - 1, adjacentJ[adj] - 1] < 10)
                {
                    adjacentCount++;
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);

                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj] - 1;
                    adjacentJ[adjPosition] = adjacentJ[adj] - 1;
                }

                //右上を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] - 1, adjacentJ[adj]] && array[adjacentI[adj] - 1, adjacentJ[adj]] < 10)
                {
                    adjacentCount++;
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);

                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj] - 1;
                    adjacentJ[adjPosition] = adjacentJ[adj];
                }

                //右を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj], adjacentJ[adj] + 1] && array[adjacentI[adj], adjacentJ[adj] + 1] < 10)
                {
                    adjacentCount++;
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);

                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj];
                    adjacentJ[adjPosition] = adjacentJ[adj] + 1;
                }

                //右下を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] + 1, adjacentJ[adj]] && array[adjacentI[adj] + 1, adjacentJ[adj]] < 10)
                {
                    adjacentCount++;
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);

                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj] + 1;
                    adjacentJ[adjPosition] = adjacentJ[adj];
                }

                //左下を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] + 1, adjacentJ[adj] - 1] && array[adjacentI[adj] + 1, adjacentJ[adj] - 1] < 10)
                {
                    adjacentCount++;
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;

                    print(1);

                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj] + 1;
                    adjacentJ[adjPosition] = adjacentJ[adj] - 1;
                }


                //左を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj], adjacentJ[adj] - 1] && array[adjacentI[adj], adjacentJ[adj] - 1] < 10)
                {
                    adjacentCount++;
                    array[adjacentI[adj], adjacentJ[adj]] += -20;
                    destroyCount++;


                    print(1);


                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj];
                    adjacentJ[adjPosition] = adjacentJ[adj] - 1;
                }
            }
            if (adjacentCount > 0)
            {
                array[adjacentI[adj], adjacentJ[adj]] += 10;
            }
        }
    }
}
