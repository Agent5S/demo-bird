using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSkin : MonoBehaviour
{
    public int selected = 0;

    public void SetSelected(int i)
    {
        selected = i;
    }

    public void AcceptSkin()
    {
        GameState.global.Skin = selected;
        SceneManager.UnloadSceneAsync(5);
    }
}
