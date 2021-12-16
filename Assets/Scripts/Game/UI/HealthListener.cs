using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthListener : MonoBehaviour
{
    private Slider healthbar;

    private void Awake()
    {
        this.healthbar = GetComponent<Slider>();
    }

    private void OnHealthChange()
    {
        var state = GameState.global;
        this.healthbar.value = state.Health / state.maxHealth;

        if (state.Health <= 0)
        {
            SceneManager.UnloadSceneAsync(3);
            SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive);
        }
    }

    private void OnEnable()
    {
        GameState.OnHealthChange += OnHealthChange;
    }

    private void OnDisable()
    {
        GameState.OnHealthChange -= OnHealthChange;
    }
}
