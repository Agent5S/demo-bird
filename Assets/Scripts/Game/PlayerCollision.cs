using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CameraShake shaker;
    private Rigidbody2D rb;
    public float hitDamage;
    public float borderImpulse;
    private int borderLayer;
    private int pipeLayer;
    private int scoreLayer;

    private void Awake()
    {
        this.borderLayer = LayerMask.NameToLayer("Border");
        this.pipeLayer = LayerMask.NameToLayer("Pipe");
        this.scoreLayer = LayerMask.NameToLayer("ScoreArea");
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == pipeLayer)
        {
            StartCoroutine(shaker.Shake());
            GameState.global.Health -= hitDamage;
        }
        if (collision.gameObject.layer == borderLayer)
        {
            StartCoroutine(shaker.Shake());
            GameState.global.Health -= hitDamage;
            var impulse = rb.position.y > 0 ? -borderImpulse : borderImpulse;
            rb.velocity = new Vector2(0, impulse);

        } else if (collision.gameObject.layer == scoreLayer)
        {
            GameState.global.Score += 1;
        }
    }
}
