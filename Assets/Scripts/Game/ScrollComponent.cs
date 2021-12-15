using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollComponent : MonoBehaviour
{
    public float minPos;
    public float maxPos;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var xPos = position.x + speed * Time.deltaTime;
        xPos = xPos < minPos ? maxPos - minPos + xPos : xPos;
        position.x = xPos;
        transform.position = position;
    }
}
