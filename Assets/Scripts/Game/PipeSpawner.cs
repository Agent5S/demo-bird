using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public Rigidbody2D prefab;
    public Vector2 origin;
    public float scrollSpeed;
    public float minHeight;
    public float heightDelta;
    public float spawnInterval;

    private bool continueCoroutine = true;
    private WaitForSeconds wait;
    private List<Rigidbody2D> pipePool = new List<Rigidbody2D>();

    private void Awake()
    {
        this.wait = new WaitForSeconds(spawnInterval);
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnPipe());
        GameState.OnDeath += DisableSelf;
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnPipe());
        GameState.OnDeath -= DisableSelf;
    }

    private IEnumerator SpawnPipe()
    {
        while (continueCoroutine)
        {
            var rand = Random.value;
            var origin = this.origin;
            origin.y = minHeight + (rand * heightDelta);

            var rb = dequeuePipe();
            rb.transform.position = origin;
            rb.gameObject.SetActive(true);
            rb.velocity = new Vector2(-scrollSpeed, 0);
            yield return wait;
        }
    }

    //FIXME: Dequeueing takes linear time
    private Rigidbody2D dequeuePipe()
    {
        for (int i = 0; i < pipePool.Count; i++)
        {
            var rb = pipePool[i];
            if (!rb.gameObject.activeInHierarchy)
            {
                return rb;
            }
        }

        //Create pipe and add to pool if none is available
        var pipe = Instantiate(prefab, transform);
        this.pipePool.Add(pipe);
        return pipe;
    }

    private void DisableSelf()
    {
        this.enabled = false;
    }
}
