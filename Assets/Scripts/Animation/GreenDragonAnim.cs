using UnityEngine;

public class GreenDragonAnim : SingletonMonoBehaviour<GreenDragonAnim>
{
    private Animator _greenDragonAnim = default;

    private const string GREEN_DRAGON_ANIM_TRIGGER = "move";

    private void Start()
    {
        _greenDragonAnim = GameObject.FindWithTag(Tags.GREEN_DRAGON).GetComponent<Animator>();
    }
    public void ReloadAnim()
    {
        _greenDragonAnim.SetTrigger(GREEN_DRAGON_ANIM_TRIGGER);
    }
}
