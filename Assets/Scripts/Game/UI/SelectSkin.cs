using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectSkin : MonoBehaviour
{
    public Image preview;
    public int selected = 0;
    public Sprite[] sprites;

    public void SetSelected(int i)
    {
        preview.sprite = sprites[i];
        selected = i;
    }

    private void Start()
    {
        var current = GameState.global.Skin;
        this.selected = current;
        preview.sprite = sprites[current];
    }

    public void AcceptSkin()
    {
        GameState.global.Skin = selected;
        SceneManager.UnloadSceneAsync(5);
    }
}
