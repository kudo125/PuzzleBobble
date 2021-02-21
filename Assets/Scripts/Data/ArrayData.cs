using UnityEngine;
public class ArrayData : MonoBehaviour
{
    /// <summary>
    /// 13*10の配列
    /// </summary>
    public static int[,] Array
    {
        get; set;
    } = new int[13, 10];

    /// <summary>
    /// 設置したバブルの番地情報 i , j 
    /// </summary>
    public static int[] InstalledBubble
    {
        get; set;
    } = new int[2];

    public static GameObject[,] GameObjectsArray
    {
        get; set;
    } = new GameObject[13, 10];
}
