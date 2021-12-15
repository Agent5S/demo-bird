using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameState state;
    public CameraShake shaker;
    public float hitDamage;
    private int borderLayer;
    private int pipeLayer;
    private int scoreLayer;

    private void Awake()
    {
        this.borderLayer = LayerMask.NameToLayer("Border");
        this.pipeLayer = LayerMask.NameToLayer("Pipe");
        this.scoreLayer = LayerMask.NameToLayer("ScoreArea");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == borderLayer ||
            collision.gameObject.layer == pipeLayer)
        {
            StartCoroutine(shaker.Shake());
            this.state.Health -= hitDamage;
        } else if (collision.gameObject.layer == scoreLayer)
        {
            this.state.Score += 1;
        }
    }
}
