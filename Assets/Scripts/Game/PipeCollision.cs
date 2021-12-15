using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollision : MonoBehaviour
{
    public GameObject trigger;

    private void OnEnable()
    {
        this.trigger.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.trigger.SetActive(false);
    }
}
