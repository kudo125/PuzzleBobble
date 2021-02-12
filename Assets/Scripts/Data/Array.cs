public class Array
{
    /// <summary>
    /// 13*10の配列
    /// </summary>
    private int[,] array = new int[13, 10];

    public int[,] GetArray()
    {
        return array;
    }

    public void SetArray(int[,] setArray)
    {
        array = setArray;
    }

    public void SetValue(int i,int j, int value)
    {
        array[i, j] = value;
    }
}
