using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel;

    void Start()
    {
        scoreLabel.text = $"{GameState.global.Score}";
    }
}
