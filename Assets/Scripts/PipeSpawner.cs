using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 origin;
    public float scrollSpeed;
    public float minHeight;
    public float heightDelta;
    public float spawnInterval;

    private bool continueCoroutine = true;
    private WaitForSeconds wait;

    private void Awake()
    {
        this.wait = new WaitForSeconds(spawnInterval);
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnPipe());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        while (continueCoroutine)
        {
            var origin = this.origin;
            origin.y += minHeight + Random.value * heightDelta;

            var pipe = Instantiate(prefab);
            var rb = pipe.GetComponent<Rigidbody2D>();
            rb.position = origin;
            rb.velocity = new Vector2(-scrollSpeed, 0);
            yield return wait;
        }
    }
}
