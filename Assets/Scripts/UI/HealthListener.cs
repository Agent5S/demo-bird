using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthListener : MonoBehaviour
{
    public GameState state;

    private Slider healthbar;

    private void Awake()
    {
        this.healthbar = GetComponent<Slider>();
    }

    private void OnHealthChange()
    {
        Debug.Log($"Health: {state.Health}");
        this.healthbar.value = state.Health / state.maxHealth;
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
