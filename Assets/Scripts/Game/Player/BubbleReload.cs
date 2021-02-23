using System.Collections;
using UnityEngine;

public class BubbleReload : SingletonMonoBehaviour<BubbleReload>
{
    public IEnumerator Reload()
    {
        GreenDragonAnim.Instance.ReloadAnim();
        yield return new WaitForSeconds(0.3f);
        NextBubble.Instance.SetShotBubble();

        //リロード後にプレイヤーステータスを変更
        GameStatus.PlayerStatusReactiveProperty.Value = PlayerStatusEnum.ShotExecuted;
        yield break;
    }
}
