public class Initialize
{
    /// <summary>
    /// 一次元配列を0で初期化
    /// </summary>
    public static int[] InitializeOneDimensionalArray(int[] OneDimensionalArray)
    {
        for (int i = 0; i < OneDimensionalArray.Length; i++)
        {
            OneDimensionalArray[i] = 0;
        }
        return OneDimensionalArray;
    }

    /// <summary>
    /// 二次元配列を0で初期化
    /// </summary>
    public static int[,] InitializeTwoDimensionalArray(int[,] TwoDimensionalArray)
    {
        for (int i = 0; i < TwoDimensionalArray.GetLength(0); i++)
        {
            for(int j = 0; i < TwoDimensionalArray.GetLength(1); i++)
            {
                TwoDimensionalArray[i, j] = 0;
            }
        }
        return TwoDimensionalArray;
    }
}
