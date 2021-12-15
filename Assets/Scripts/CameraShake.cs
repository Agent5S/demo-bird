using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class CameraShake : MonoBehaviour
{
    public float shakeStrength;
    public float shakeTime;

    public Camera Camera { get; private set; }

    private float remainingShakeTime;
    private float currentStrength;

    private void Awake()
    {
        this.Camera = GetComponent<Camera>();
    }

    public IEnumerator Shake()
    {
        var originalPosition = transform.position;
        this.remainingShakeTime = shakeTime;
        this.currentStrength = shakeStrength;

        while (remainingShakeTime > 0)
        {
            var y = currentStrength * (2 * Random.value - 1);

            var position = transform.position;
            position.y = y;
            this.transform.position = position;

            this.currentStrength = Mathf.MoveTowards(currentStrength, 0, shakeStrength * Time.deltaTime);
            this.remainingShakeTime -= Time.deltaTime;
            yield return null;
        }

        this.transform.position = originalPosition;
    }
}
