using UnityEngine;

public class ArrayManager : MonoBehaviour
{
    /// <summary>
    /// 13*10の配列
    /// </summary>
    private int[,] array = new int[13, 10];

    /// <summary>
    /// 隣接判定用配列
    /// </summary>
    private int[,] hangingArray = new int[13, 10];

    /// <summary>
    /// 消すバブルの番地情報格納用配列I
    /// </summary>
    private int[] destroyI = new int[130];

    /// <summary>
    /// 消すバブルの番地情報格納用配列J
    /// </summary>
    private int[] destroyJ = new int[130];

    /// <summary>
    /// 消すバブルの番地情報格納用配列　の　番地情報
    /// </summary>
    private int destroyCount = default;

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

    private GameObject audioController = default;

    private GameController gameController = default;

    const string audioTag = "Audio";

    /// <summary>
    /// 配列内のデフォルト最小値
    /// </summary>
    const int minValue = -2;

    const int hangingCounter = 20;

    private void Start()
    {
        //初期化
        for (int i = 0; i < array.GetLength(0); ++i)
        {
            for (int j = 0; j < array.GetLength(1); ++j)
            {
                if (i == 0)
                {
                    array[i, j] = -2;
                }
                else if (i == 12)
                {
                    array[i, j] = -1;
                }
                else if (j == 0 || j == 9)
                {
                    array[i, j] = -1;
                }
                else if (j == 8 && i % 2 == 0)
                {
                    array[i, j] = -1;
                }
                else
                {
                    array[i, j] = 0;
                }
            }
        }

        audioController = GameObject.FindWithTag(audioTag);

        gameController = GetComponent<GameController>();

        gameController.GameStart();
    }

    public void SetValue(int i , int j ,int value)
    {
        array[i, j] = value;
        BubbleCheck(i,j);
    }

    private void BubbleCheck(int i, int j)
    {

        //初期化
        adjacentCount = default;
        destroyCount = default;
        for (int DesI = 0; DesI < destroyI.GetLength(0); ++DesI)
        {
            destroyI[DesI] = 0;
        }
        for (int DesJ = 0; DesJ < destroyJ.GetLength(0); ++DesJ)
        {
            destroyJ[DesJ] = 0;
        }
        for (int adjI = 0; adjI < adjacentI.GetLength(0); ++adjI)
        {
            adjacentI[adjI] = -5;
        }
        for (int adjJ = 0; adjJ < adjacentJ.GetLength(0); ++adjJ)
        {
            adjacentJ[adjJ] = -5;
        }

        //隣接バブルをチェック
        AdjacentCheck(i, j);
       
        if (adjacentCount >= 2)
        {
            destroyI[destroyCount] = i;
            destroyJ[destroyCount] = j;
            BubbleDestroy();
            NotAdjacentCheck();

            audioController.GetComponent<AudioController>().destroySEPlay();

            //消す処理終わり
        }
        else
        {
            NotDestroy(10);
        }

        gameController.GameEndCheck(array);
    }

    /// <summary>
    ///　隣接するバブルがなくなるまで再起処理をする
    /// </summary>
    private void AdjacentCheck(int i,int j)
    {
        adjacentI[0] = i;
        adjacentJ[0] = j;

        int adjPosition = default; ;

        for (int adj = 0; adjacentI[adj] > -5; adj++)
        {
            if (adjacentI[adj] % 2 == 0)
            {
                //左上を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] - 1, adjacentJ[adj]] && array[adjacentI[adj] - 1, adjacentJ[adj]] < 10)
                {
                    adjacentCount++;
                    destroyI[destroyCount] = adjacentI[adj] - 1;
                    destroyJ[destroyCount] = adjacentJ[adj];
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
                    destroyI[destroyCount] = adjacentI[adj] - 1;
                    destroyJ[destroyCount] = adjacentJ[adj] + 1;
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
                    destroyI[destroyCount] = adjacentI[adj];
                    destroyJ[destroyCount] = adjacentJ[adj] + 1;
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
                    destroyI[destroyCount] = adjacentI[adj] + 1;
                    destroyJ[destroyCount] = adjacentJ[adj] + 1;
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
                    destroyI[destroyCount] = adjacentI[adj] + 1;
                    destroyJ[destroyCount] = adjacentJ[adj];
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
                    destroyI[destroyCount] = adjacentI[adj];
                    destroyJ[destroyCount] = adjacentJ[adj] - 1;
                    destroyCount++;

                    print(1);


                    adjPosition++;
                    adjacentI[adjPosition] = adjacentI[adj] ;
                    adjacentJ[adjPosition] = adjacentJ[adj] - 1;
                }
            }
            else
            {
                //左上を見る
                if (array[adjacentI[adj], adjacentJ[adj]] == array[adjacentI[adj] - 1, adjacentJ[adj] - 1] && array[adjacentI[adj] - 1, adjacentJ[adj] - 1] < 10)
                {
                    adjacentCount++;
                    destroyI[destroyCount] = adjacentI[adj] - 1;
                    destroyJ[destroyCount] = adjacentJ[adj] - 1;
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
                    destroyI[destroyCount] = adjacentI[adj] - 1;
                    destroyJ[destroyCount] = adjacentJ[adj];
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
                    destroyI[destroyCount] = adjacentI[adj];
                    destroyJ[destroyCount] = adjacentJ[adj] + 1;
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
                    destroyI[destroyCount] = adjacentI[adj] + 1;
                    destroyJ[destroyCount] = adjacentJ[adj];
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
                    destroyI[destroyCount] = adjacentI[adj] + 1;
                    destroyJ[destroyCount] = adjacentJ[adj] - 1;
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
                    destroyI[destroyCount] = adjacentI[adj];
                    destroyJ[destroyCount] = adjacentJ[adj] - 1;
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

    private void BubbleDestroy()
    {
        GameObject[] bubbleObjs = GameObject.FindGameObjectsWithTag("Placed");

        for (int destroyNum = 0; destroyI[destroyNum] > 0; destroyNum++)
        {
            for (int i = 0; i < bubbleObjs.GetLength(0); i++)
            {
                int bubbleI = bubbleObjs[i].GetComponent<BubblePosition>().GetBubblePositionI();
                int bubbleJ = bubbleObjs[i].GetComponent<BubblePosition>().GetBubblePositionJ();

               
                if (bubbleI == destroyI[destroyNum] && bubbleJ == destroyJ[destroyNum])
                {
                    bubbleObjs[i].GetComponent<BubbleDestroyEfect>().DestroyEfect();

                    array[bubbleI,bubbleJ] = 0;

                }
            }
        }
    }

    /// <summary>
    /// どこにもつながっていないバブルを消す
    /// </summary>
    private void NotAdjacentDestroy(int i,int j)
    {
        GameObject[] bubbleObjs = GameObject.FindGameObjectsWithTag("Placed");

        for(int objI = 0; objI < bubbleObjs.GetLength(0); ++objI)
        {
            int bubbleI = bubbleObjs[objI].GetComponent<BubblePosition>().GetBubblePositionI();
            int bubbleJ = bubbleObjs[objI].GetComponent<BubblePosition>().GetBubblePositionJ();

            if (i == bubbleI && j == bubbleJ)
            {
                bubbleObjs[objI].GetComponent<BubbleDestroyEfect>().Drop();

                array[bubbleI, bubbleJ] = 0;
            }
        }

    }

    private void NotAdjacentCheck()
    {
        //初期化
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

        for (int j = 0; j < array.GetLength(1) ; ++j)
        {
            if(array[1, j] > 0)
            {
                hangingArray[1, j] = 1;
                HangingCheck(1, j);
            }
            
        }

        for (int i = 0; i < hangingArray.GetLength(0); ++i)
        {
            for (int j = 0; j < hangingArray.GetLength(1); ++j)
            {
                if (hangingArray[i, j] == 0)
                {
                    NotAdjacentDestroy(i,j);
                }
            }
        }

        NotAdjacent(20, -10);
    }

    /// <summary>
    /// ぶら下がり判定
    /// </summary>
    private void HangingCheck(int i,int j)
    {
        //初期化
        for (int hangI = 0; hangI < hangingI.GetLength(0); hangI++)
        {
            hangingI[hangI] = -1;
        }
        for (int hangJ = 0; hangJ < hangingJ.GetLength(0); hangJ++)
        {
            hangingJ[hangJ] = -1;
        }
        hangingCount = default;

        hangingI[hangingCount] = i;
        hangingJ[hangingCount] = j;

        for (int hang=0;hangingI[hang]>-1;hang++)
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
                    array[hangingI[hang], hangingJ[hang]-1] -= hangingCounter;
                }
            }

            if (hangingCount > 0&& array[hangingI[hang], hangingJ[hang]]>-10)
            {
                array[hangingI[hang], hangingJ[hang]] -= 20;
                print(hang+"  ||  "+ array[hangingI[hang], hangingJ[hang]]+"|"+ hangingI[hang]+ "|" + hangingJ[hang]);
            }
        }
       
    }

    private void NotDestroy(int Difference)
    {
        for (int i = 0; i < array.GetLength(0); ++i)
        {
            for (int j = 0; j < array.GetLength(1); ++j)
            {
                if (array[i, j] >= Difference)
                {
                    array[i, j] -= Difference;
                }
            }
        }

    }

    private void NotAdjacent(int Difference,int Comparison)
    {
        for (int i = 0; i < array.GetLength(0); ++i)
        {
            for (int j = 0; j < array.GetLength(1); ++j)
            {
                if (array[i, j] <= Comparison)
                {
                    array[i, j] += Difference;
                }
            }
        }

    }

    public void SetStage(int[,] stage)
    {
        for (int i = 0; i < array.GetLength(0); ++i)
        {
            for (int j = 0; j < array.GetLength(1); ++j)
            {
                array[i, j] = stage[i,j];

            }
        }
    }

    public void DebagArray()
    {

        string str=default;

        for (int i = 0; i < array.GetLength(0); ++i)
        {
            for (int j = 0; j < array.GetLength(1); ++j)
            {
                str += ","+array[i, j];
            }

            Debug.Log(str);
            str = "";
        }


    }

}

