using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadCsv : SingletonMonoBehaviour<LoadCsv>
{
    private int[,] _array = default;

    private int _stageNum = default;

    protected override void Awake()
    {        
        _array = ArrayData.Array;
    }

    public void LoadStage()
    {
        //初期化
        for (int i = 0; i < _array.GetLength(0); ++i)
        {
            for (int j = 0; j < _array.GetLength(1); ++j)
            {
                if (i == 0)
                {
                    _array[i, j] = -2;
                }
                else if (i == _array.GetLength(0))
                {
                    _array[i, j] = -1;
                }
                else if (j == 0 || j == _array.GetLength(1))
                {
                    _array[i, j] = -1;
                }
                else if (j == _array.GetLength(1)-1 && i % 2 == 0)
                {
                    _array[i, j] = -1;
                }
                else
                {
                    _array[i, j] = 0;
                }
            }
        }
        StartCoroutine(ReadCsv());
    }

    /// <summary>
    /// CSV読み込んで準備
    /// </summary>
    IEnumerator ReadCsv()
    {
        _stageNum++;

        string textFileName = "Stage"+_stageNum+".csv";

        string path = null;

        path = Application.dataPath + "/StreamingAssets" + "/" + textFileName;

        UnityWebRequest unityWebRequest;

        unityWebRequest = UnityWebRequest.Get(path);

        yield return unityWebRequest.SendWebRequest();

        ReadIntervalCSVData(unityWebRequest.downloadHandler.text);

        yield break;
    }

    /// <summary>
    /// CSVデータをint型２次元配列に変換する
    /// </summary>
    /// <param name="csvData">CSVデータ</param>
    private void ReadIntervalCSVData(string csvData)
    {
        // StringSplitOptionを設定(要はカンマとカンマに何もなかったら格納しないことにする)
        StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;

        // 行に分ける
        string[] lines = csvData.Split(new char[] { '\r', '\n' }, option);

        // カンマ分けの準備(区分けする文字を設定する)
        char[] spliter = new char[1] { ',' };

        // 行データを切り分けて,2次元配列へ変換する
        for (int i = 1; i < _array.GetLength(0)-1; i++)
        {
            string[] splitedData = lines[i-1].Split(spliter, option);

            for (int j = 1; j < _array.GetLength(1)-1; j++)
            {
                //int型になおして格納
                _array[i, j] = int.Parse(splitedData[j-1]);
            }
        }

        //終了後ゲームステータス変更
        GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.LoadedStage;
    }
}
