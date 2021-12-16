using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathListener : MonoBehaviour
{
    public static readonly int FlyingParamId = Animator.StringToHash("Flying");

    private PlayerJump jump;
    private Animator animator;
    private new Collider2D collider;

    private int gameOverLayer;

    private void Awake()
    {
        this.jump = GetComponent<PlayerJump>();
        this.animator = GetComponent<Animator>();
        this.collider = GetComponent<Collider2D>();
        this.gameOverLayer = LayerMask.NameToLayer("GameOver");
    }

    private void OnDeath()
    {
        animator.SetBool(FlyingParamId, false);
        SceneManager.UnloadSceneAsync(3);
        SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive);
        collider.isTrigger = false;
        gameObject.layer = gameOverLayer;
        jump.enabled = false;
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
