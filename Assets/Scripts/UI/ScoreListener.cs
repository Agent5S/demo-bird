using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreListener : MonoBehaviour
{
    public GameState state;

    private TextMeshProUGUI text;

    private void Awake()
    {
        this.text = GetComponent<TextMeshProUGUI>();
    }

    private void OnScoreChange()
    {
        this.text.text = $"{state.Score}";
    }

    private void OnEnable()
    {
        GameState.OnScoreChange += OnScoreChange;
    }

    private void OnDisable()
    {
        GameState.OnScoreChange -= OnScoreChange;
    }
}
