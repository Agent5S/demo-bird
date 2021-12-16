using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState global;

    public delegate void ScoreChange();
    public static event ScoreChange OnScoreChange;

    public delegate void HealthChange();
    public static event HealthChange OnHealthChange;

    public delegate void Died();
    public static event Died OnDeath;

    public float maxHealth;

    private int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            OnScoreChange?.Invoke();
        }
    }

    private float health;
    public float Health
    {
        get => health;
        set
        {
            health = value;
            OnHealthChange?.Invoke();
            if (health <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        this.health = maxHealth;
        GameState.global = this;
    }
}
