using UnityEngine;

public class StageSet : MonoBehaviour
{
    private ArrayManager arrayManager = default;

         
    private void Awake()
    {
        arrayManager = GetComponent<ArrayManager>();
    }

    public void LoadStage()
    {
        int[,] stage =new int[13, 10]
        {
                                      { -2,-2,-2,-2,-2,-2,-2,-2,-2,-2},
                                      { -1, 1, 1, 5, 5, 3, 3, 2, 2,-1},
                                      { -1, 1, 1, 5, 5, 3, 3, 2,-1,-1},
                                      { -1, 2, 2, 3, 3, 1, 1, 5, 5,-1},
                                      { -1, 2, 3, 3, 1, 1, 5, 5,-1,-1},
                                      { -1, 0, 0, 0, 0, 0, 0, 0, 0,-1},
                                      { -1, 0, 0, 0, 0, 0, 0, 0,-1,-1},
                                      { -1, 0, 0, 0, 0, 0, 0, 0, 0,-1},
                                      { -1, 0, 0, 0, 0, 0, 0, 0,-1,-1},
                                      { -1, 0, 0, 0, 0, 0, 0, 0, 0,-1},
                                      { -1, 0, 0, 0, 0, 0, 0, 0,-1,-1},
                                      { -1, 0, 0, 0, 0, 0, 0, 0, 0,-1},
                                      { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1}
        };

        arrayManager.SetStage(stage);

    }
}
