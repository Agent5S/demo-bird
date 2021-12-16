using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSkinSelector : MonoBehaviour
{
    public void OpenSelector()
    {
        SceneManager.LoadSceneAsync(5, LoadSceneMode.Additive);
    }
}
