using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
    }
}