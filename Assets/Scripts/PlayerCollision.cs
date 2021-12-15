using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CameraShake shaker;
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
        if (collision.gameObject.layer == borderLayer)
        {
            Debug.Log("Hit border");
            StartCoroutine(shaker.Shake());
        } else if (collision.gameObject.layer == pipeLayer)
        {
            Debug.Log("Hit pipe");
            StartCoroutine(shaker.Shake());
        } else if (collision.gameObject.layer == scoreLayer)
        {
            Debug.Log("Point scored");
        }
    }
}
