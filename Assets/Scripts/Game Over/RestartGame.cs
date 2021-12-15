using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadSceneAsync("Menu");
        //Reset Game State
        Destroy(GameObject.Find("Game State"));
    }
}
