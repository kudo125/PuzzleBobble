using UnityEngine;
/// <summary>
/// 配列初期化クラス
/// </summary>
public class Initialize : MonoBehaviour
{
    /// <summary>
    /// 一次元配列(int)を0で初期化
    /// </summary>
    public static int[] IntInitializeOneDimensionalArray(int[] OneDimensionalArray)
    {
        for (int i = 0; i < OneDimensionalArray.Length; i++)
        {
            OneDimensionalArray[i] = 0;
        }
        return OneDimensionalArray;
    }

    /// <summary>
    /// 二次元配列(int)を0で初期化
    /// </summary>
    public static int[,] IntInitializeTwoDimensionalArray(int[,] TwoDimensionalArray)
    {
        for (int i = 0; i < TwoDimensionalArray.GetLength(0); i++)
        {
            for (int j = 0; j < TwoDimensionalArray.GetLength(1); j++)
            {
                TwoDimensionalArray[i, j] = 0;
            }
        }
        return TwoDimensionalArray;
    }

    /// <summary>
    /// 二次元配列(GameObject)をDestroy
    /// </summary>
    public static GameObject[,] GameObjectsInitializeTwoDimensionalArray(GameObject[,] TwoDimensionalArray)
    {
        for (int i = 0; i < TwoDimensionalArray.GetLength(0); i++)
        {
            for (int j = 0; j < TwoDimensionalArray.GetLength(1); j++)
            {
                Destroy(TwoDimensionalArray[i, j]);
                TwoDimensionalArray[i, j] = null;
            }
        }

        return TwoDimensionalArray;
    }
}