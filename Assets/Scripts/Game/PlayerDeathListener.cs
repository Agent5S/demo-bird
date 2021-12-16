using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathListener : MonoBehaviour
{
    public static readonly int FlyingParamId = Animator.StringToHash("Flying");

    private Animator animator;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
    }

    private void OnDeath()
    {
        animator.SetBool(FlyingParamId, false);
        SceneManager.UnloadSceneAsync(3);
        SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        GameState.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        GameState.OnDeath -= OnDeath;
    }
}
