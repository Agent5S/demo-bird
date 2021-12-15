using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateReset : MonoBehaviour
{
    void Start()
    {
        var state = GameState.global;
        state.Health = state.maxHealth;
        state.Score = 0;
    }
}
