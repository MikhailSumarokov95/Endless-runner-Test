using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private float _difficulty = 1;
    private int _boost = 1;
    private ScoreManager _scoreManager;
    private StatusGameManager _statusGameManager;
    private bool _isStopedUpDifficulty;

    public float SpeedGame
    {
        get { return _difficulty * _boost; }
    }

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _statusGameManager = FindObjectOfType<StatusGameManager>();
        _statusGameManager.onPausedGame += StopUpDifficulty;
        _statusGameManager.onStartedGame += StartUpDifficulty;
    }

    private void Update()
    {
        if (!_isStopedUpDifficulty) UpDifficulty();
    }

    public void SetBoost()
    {
        _boost = 2;
        StartCoroutine(BoostTimer());
        _scoreManager.SetBoost(true);
    }

    private void UpDifficulty() => _difficulty += 0.01f * Time.deltaTime;

    private void StopUpDifficulty() => _isStopedUpDifficulty = true;

    private void StartUpDifficulty() => _isStopedUpDifficulty = false;

    private IEnumerator BoostTimer()
    {
        yield return new WaitForSeconds(10);
        _boost = 1;
        _scoreManager.SetBoost(false);
    }
}
