using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private bool _gameIsOver;
    private float _difficulty = 1;
    public float SpeedGame
    {
        get { return _difficulty; }
    }

    private void Update()
    {
        if (!_gameIsOver) UpDifficulty();
    }

    public void GameOver()
    {
        _gameIsOver = true;
        _difficulty = 0;
    }

    private void UpDifficulty()
    {
        _difficulty += 0.01f * Time.deltaTime;
    }
}
