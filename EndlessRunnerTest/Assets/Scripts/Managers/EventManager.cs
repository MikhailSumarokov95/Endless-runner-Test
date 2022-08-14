using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private UIManager _UIManager;
    private DifficultyManager _difficultyManager;
    private AnimationManager _animationManager;
    private SoundManager _soundManager;

    private void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        _UIManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
        _difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        _animationManager = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationManager>();
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void PickUpCoin(Vector3 coinPosition)
    {
        _scoreManager.PickUpCoin();
        _animationManager.PickUpCoin(coinPosition);
        _soundManager.PickUpCoin();
    }

    public void PickUpCoinBoost(Vector3 coinBoostPosition)
    {
        _animationManager.PickUpCoinBoost(coinBoostPosition);
        _soundManager.PickUpCoinBoost();
        _scoreManager.SetBoost();
        _difficultyManager.SetBoost();
        StartCoroutine(BoostTimer());
    }

    public void CrushObstacle(Vector3 ObstackePosition)
    {
        _UIManager.GameOver();
        _difficultyManager.GameOver();
        _animationManager.CrashObstacle(ObstackePosition);
        _soundManager.CrashObstacle();
    }

    private IEnumerator BoostTimer()
    {
        yield return new WaitForSeconds(10);
        _scoreManager.ResetBoost();
        _difficultyManager.ResetBoost();
    }
}
