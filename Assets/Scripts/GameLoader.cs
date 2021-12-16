using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader
{
    [RuntimeInitializeOnLoadMethod]
    public static void LoadGame()
    {
        var op = SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        op.completed += _ =>
        {
            SceneManager.UnloadSceneAsync(3);
        };
    }
}
