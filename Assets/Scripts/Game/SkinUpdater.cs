using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinUpdater : MonoBehaviour
{
    public AnimationClip[] flyClips;
    public AnimationClip[] deathClips;

    private Animator animator;

    const string a = "Flying";

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
    }

    private void Start()
    {
        OnUpdateSkin();
    }

    private void OnUpdateSkin()
    {
        var newAnim =
            new AnimatorOverrideController(animator.runtimeAnimatorController);
        newAnim["Fly 1"] = flyClips[GameState.global.Skin];
        newAnim["Dead 1"] = deathClips[GameState.global.Skin];
        animator.runtimeAnimatorController = newAnim;
        animator.runtimeAnimatorController.name = "Override Player Animator";
    }

    private void OnEnable()
    {
        GameState.OnUpdateSkin += OnUpdateSkin;
    }

    private void OnDisable()
    {
        GameState.OnUpdateSkin -= OnUpdateSkin;
    }
}
