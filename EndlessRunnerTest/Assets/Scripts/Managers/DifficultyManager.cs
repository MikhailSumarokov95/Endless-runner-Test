using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private bool _gameIsOver;
    private float _difficulty = 1;
    private int _boost = 1;

    public float SpeedGame
    {
        get { return _difficulty * _boost; }
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

    public void SetBoost()
    {
        _boost = 2;
    }

    public void ResetBoost()
    {
        _boost = 1;
    }

    private void UpDifficulty()
    {
        _difficulty += 0.01f * Time.deltaTime;
    }
}
