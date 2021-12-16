using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
    }
}
