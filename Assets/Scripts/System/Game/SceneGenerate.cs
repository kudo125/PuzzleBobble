using UnityEngine;

public class SceneGenerate : MonoBehaviour
{
    private GameObject[] sceneInstances = default;

    private void Awake()
    {
        //ResourcesからSceneオブジェクトを読み込み
        GameObject[] scenePrefabs = new GameObject[3]
        {
            (GameObject)Resources.Load(ResourcesPass.PREFAB_PASS + "/" + ResourcesPass.TITLE_SCENE),
            (GameObject)Resources.Load(ResourcesPass.PREFAB_PASS + "/" + ResourcesPass.MENU_SCENE),
            (GameObject)Resources.Load(ResourcesPass.PREFAB_PASS + "/" + ResourcesPass.GAME_SCENE)
        };

        sceneInstances = new GameObject[scenePrefabs.Length];

        //Sceneを生成
        for (int i = 0; i < scenePrefabs.Length; i++)
        {
            sceneInstances[i] = Instantiate(scenePrefabs[i]);
            sceneInstances[i].transform.parent = this.gameObject.transform;
        }
    }
}