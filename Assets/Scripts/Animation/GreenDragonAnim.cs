using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDragonAnim : SingletonMonoBehaviour<GreenDragonAnim>
{
    private Animator greenDragonAnim = default;

    private const string greenDragonAnimationTrigger = "move";

    private void Start()
    {
        greenDragonAnim = GameObject.FindWithTag(Tags.GREEN_DRAGON).GetComponent<Animator>();
    }
    public void ReloadAnim()
    {
        greenDragonAnim.SetTrigger(greenDragonAnimationTrigger);
    }
}
