using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
