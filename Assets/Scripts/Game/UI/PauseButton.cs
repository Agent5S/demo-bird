using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Sprite playSrite;
    public Sprite pauseSprite;

    public Image image;

    public void Pause()
    {
        var pause = Time.timeScale > 0;
        this.image.sprite = pause ? playSrite : pauseSprite;
        Time.timeScale = pause ? 0 : 1;
    }
}
