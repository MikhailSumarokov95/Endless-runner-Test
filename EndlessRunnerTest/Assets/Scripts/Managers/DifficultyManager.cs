using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private float _difficulty = 1;
    private int _boost = 1;
    private StatusGameManager _statusGameManager;
    private bool _isStopedUpDifficulty;

    public float SpeedGame
    {
        get { return _difficulty * _boost; }
    }

    private void Start()
    {
        _statusGameManager = FindObjectOfType<StatusGameManager>();
        _statusGameManager.onPausedGame += StopUpDifficulty;
        _statusGameManager.onStartedGame += StartUpDifficulty;
    }

    private void Update()
    {
        if (!_isStopedUpDifficulty) UpDifficulty();
    }

    public void SetBoost(bool isActive)
    {
        if (isActive) _boost = 2;
        else _boost = 1;
    }

    private void UpDifficulty() => _difficulty += 0.01f * Time.deltaTime;

    private void StopUpDifficulty() => _isStopedUpDifficulty = true;

    private void StartUpDifficulty() => _isStopedUpDifficulty = false;
}
