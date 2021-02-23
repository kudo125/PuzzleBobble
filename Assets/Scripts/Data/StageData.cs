using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class StageData : MonoBehaviour
{
    private const string STAGE_ORDER = "StageOrder.csv";

    private void Awake()
    {
        ReadCsv();
    }

    /// <summary>
    /// ステージ数
    /// </summary>
    public static int StageQuantity
    {
        get;private set;
    }

    /// <summary>
    /// CSV読み込み
    /// </summary>
    IEnumerator ReadCsv()
    {
        string textFileName = STAGE_ORDER;

        string path = null;

        path = Application.dataPath + "/StreamingAssets" + "/" + textFileName;

        UnityWebRequest unityWebRequest;

        unityWebRequest = UnityWebRequest.Get(path);

        yield return unityWebRequest.SendWebRequest();

        StageQuantity = int.Parse(unityWebRequest.downloadHandler.text);

        yield break;
    }
}
