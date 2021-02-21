public class Debug 
{
    public static void DebagArray(int[,] array)
    {

        string str = default;

        for (int i = 0; i < array.GetLength(0); ++i)
        {
            for (int j = 0; j < array.GetLength(1); ++j)
            {
                str += "," + array[i, j];
            }

            UnityEngine.Debug.Log(str);
            str = "";
        }
    }
}
