using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingCheck : MonoBehaviour
{
    /// <summary>
    /// 代入用配列
    /// </summary>
    private int[,] array = default;

    /// <summary>
    /// ぶら下がり判定用配列
    /// </summary>
    private int[,] hangingArray = new int[13, 10];

    /// <summary>
    /// ぶら下がり判定用配列I
    /// </summary>
    private int[] hangingI = new int[1000];

    /// <summary>
    /// ぶら下がり判定用配列J
    /// </summary>
    private int[] hangingJ = new int[1000];

    /// <summary>
    /// ぶら下がり判定用配列　の　番地情報
    /// </summary>
    private int hangingCount = default;

    private const int hangingCounter = 20;

    private void Start()
    {
        Array arraydata = new Array();

        array = arraydata.GetArray();

    }

    /// <summary>
    /// ぶら下がり判定
    /// </summary>
    private void HangingCheckUp(int i, int j)
    {
        
        Initialized();

        hangingCount = default;

        hangingI[hangingCount] = i;
        hangingJ[hangingCount] = j;

        for (int hang = 0; hangingI[hang] > -1; hang++)
        {
            if (hangingI[hang] % 2 == 0)
            {
                //左上を見る
                if (0 < array[hangingI[hang] - 1, hangingJ[hang]])
                {
                    hangingArray[hangingI[hang] - 1, hangingJ[hang]] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang] - 1;
                    hangingJ[hangingCount] = hangingJ[hang];
                    array[hangingI[hang] - 1, hangingJ[hang]] -= hangingCounter;
                }
                //右上を見る
                if (0 < array[hangingI[hang] - 1, hangingJ[hang] + 1])
                {
                    hangingArray[hangingI[hang] - 1, hangingJ[hang] + 1] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang] - 1;
                    hangingJ[hangingCount] = hangingJ[hang] + 1;
                    array[hangingI[hang] - 1, hangingJ[hang] + 1] -= hangingCounter;
                }
                //右を見る
                if (0 < array[hangingI[hang], hangingJ[hang] + 1])
                {
                    hangingArray[hangingI[hang], hangingJ[hang] + 1] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang];
                    hangingJ[hangingCount] = hangingJ[hang] + 1;
                    array[hangingI[hang], hangingJ[hang] + 1] -= hangingCounter;
                }
                //右下を見る
                if (0 < array[hangingI[hang] + 1, hangingJ[hang] + 1])
                {
                    hangingArray[hangingI[hang] + 1, hangingJ[hang] + 1] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang] + 1;
                    hangingJ[hangingCount] = hangingJ[hang] + 1;
                    array[hangingI[hang] + 1, hangingJ[hang] + 1] -= hangingCounter;
                }
                //左下を見る
                if (0 < array[hangingI[hang] + 1, hangingJ[hang]])
                {
                    hangingArray[hangingI[hang] + 1, hangingJ[hang]] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang] + 1;
                    hangingJ[hangingCount] = hangingJ[hang];
                    array[hangingI[hang] + 1, hangingJ[hang]] -= hangingCounter;
                }
                //左を見る
                if (0 < array[hangingI[hang], hangingJ[hang] - 1])
                {
                    hangingArray[hangingI[hang], hangingJ[hang] - 1] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang];
                    hangingJ[hangingCount] = hangingJ[hang] - 1;
                    array[hangingI[hang], hangingJ[hang] - 1] -= hangingCounter;
                }
            }
            else
            {
                //左上を見る
                if (0 < array[hangingI[hang] - 1, hangingJ[hang] - 1])
                {
                    hangingArray[hangingI[hang] - 1, hangingJ[hang] - 1] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang] - 1;
                    hangingJ[hangingCount] = hangingJ[hang] - 1;
                    array[hangingI[hang] - 1, hangingJ[hang] - 1] -= hangingCounter;
                }
                //右上を見る
                if (0 < array[hangingI[hang] - 1, hangingJ[hang]])
                {
                    hangingArray[hangingI[hang] - 1, hangingJ[hang]] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang] - 1;
                    hangingJ[hangingCount] = hangingJ[hang];
                    array[hangingI[hang] - 1, hangingJ[hang]] -= hangingCounter;
                }
                //右を見る
                if (0 < array[hangingI[hang], hangingJ[hang] + 1])
                {
                    hangingArray[hangingI[hang], hangingJ[hang] + 1] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang];
                    hangingJ[hangingCount] = hangingJ[hang] + 1;
                    array[hangingI[hang], hangingJ[hang] + 1] -= hangingCounter;
                }
                //右下を見る
                if (0 < array[hangingI[hang] + 1, hangingJ[hang]])
                {
                    hangingArray[hangingI[hang] + 1, hangingJ[hang]] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang] + 1;
                    hangingJ[hangingCount] = hangingJ[hang];
                    array[hangingI[hang] + 1, hangingJ[hang]] -= hangingCounter;
                }
                //左下を見る
                if (0 < array[hangingI[hang] + 1, hangingJ[hang] - 1])
                {
                    hangingArray[hangingI[hang] + 1, hangingJ[hang] - 1] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang] + 1;
                    hangingJ[hangingCount] = hangingJ[hang] - 1;
                    array[hangingI[hang] + 1, hangingJ[hang] - 1] -= hangingCounter;
                }
                //左を見る
                if (0 < array[hangingI[hang], hangingJ[hang] - 1])
                {
                    hangingArray[hangingI[hang], hangingJ[hang] - 1] = 1;
                    hangingCount++;
                    hangingI[hangingCount] = hangingI[hang];
                    hangingJ[hangingCount] = hangingJ[hang] - 1;
                    array[hangingI[hang], hangingJ[hang] - 1] -= hangingCounter;
                }
            }

            if (hangingCount > 0 && array[hangingI[hang], hangingJ[hang]] > -10)
            {
                array[hangingI[hang], hangingJ[hang]] -= 20;
                print(hang + "  ||  " + array[hangingI[hang], hangingJ[hang]] + "|" + hangingI[hang] + "|" + hangingJ[hang]);
            }
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialized()
    {
        for (int hangI = 0; hangI < hangingI.GetLength(0); hangI++)
        {
            hangingI[hangI] = -1;
        }

        for (int hangJ = 0; hangJ < hangingJ.GetLength(0); hangJ++)
        {
            hangingJ[hangJ] = -1;
        }

        for (int i = 0; i < hangingArray.GetLength(0); ++i)
        {
            for (int j = 0; j < hangingArray.GetLength(1); ++j)
            {
                if (i == 0)
                {
                    hangingArray[i, j] = -2;
                }
                else if (i == 12)
                {
                    hangingArray[i, j] = -1;
                }
                else if (j == 0 || j == 9)
                {
                    hangingArray[i, j] = -1;
                }
                else if (j == 8 && i % 2 == 0)
                {
                    hangingArray[i, j] = -1;
                }
                else
                {
                    hangingArray[i, j] = 0;
                }
            }
        }
    }
}
