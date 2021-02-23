using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class StageOrder : SingletonMonoBehaviour<StageOrder>
{
    private const string STAGE_ORDER = "StageOrder.csv";

    public static int StageQuantity 
    {
        get; private set;
    } = default;

    protected override void Awake()
    {
        StartCoroutine(ReadCsv());
    }

    /// <summary>
    /// OderCSV読み込んみ
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
