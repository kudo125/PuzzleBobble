using UnityEngine;
/// <summary>
/// ステージリセットクラス
/// </summary>
public class StageReset :MonoBehaviour
{
    public static void StageDestroy()
    {
        ArrayData.Array = Initialize.IntInitializeTwoDimensionalArray(ArrayData.Array);
        ArrayData.GameObjectsArray = Initialize.GameObjectsInitializeTwoDimensionalArray(ArrayData.GameObjectsArray);

        GameObject[] bubbles= GameObject.FindGameObjectsWithTag(Tags.BUBBLE);

        for(int i = 0; i < bubbles.Length; i++)
        {
            Destroy(bubbles[i]);
        }
    }
}
