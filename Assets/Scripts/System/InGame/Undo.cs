/// <summary>
/// 判定処理で変更した配列情報をもとに戻すクラス
/// </summary>
public class Undo 
{
    public static void UndoArray()
    {
        for (int i = 0; i < ArrayData.Array.GetLength(0); i++) 
        {
            for(int j=0;j < ArrayData.Array.GetLength(1); j++)
            {
                if (ArrayData.Array[i, j] > ArrayManipulation.DES_VALUE)
                {
                    ArrayData.Array[i, j] -= ArrayManipulation.DES_VALUE;
                }
            }
        }
    }
}
