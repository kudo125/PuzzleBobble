using UnityEngine;

public class SceneGenerate : MonoBehaviour
{
    private GameObject[] _sceneInstances = default;

    private void Awake()
    {
        //ResourcesからSceneオブジェクトを読み込み
        GameObject[] scenePrefabs = new GameObject[3]
        {
            (GameObject)Resources.Load(ResourcesPass.PREFAB_PASS + "/" + ResourcesPass.TITLE_SCENE),
            (GameObject)Resources.Load(ResourcesPass.PREFAB_PASS + "/" + ResourcesPass.MENU_SCENE),
            (GameObject)Resources.Load(ResourcesPass.PREFAB_PASS + "/" + ResourcesPass.GAME_SCENE)
        };

        _sceneInstances = new GameObject[scenePrefabs.Length];

        //Sceneを生成
        for (int i = 0; i < scenePrefabs.Length; i++)
        {
            _sceneInstances[i] = Instantiate(scenePrefabs[i]);
            _sceneInstances[i].transform.parent = this.gameObject.transform;
        }
    }
}