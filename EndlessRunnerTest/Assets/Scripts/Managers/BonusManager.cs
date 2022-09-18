using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _textTimerPowerUpCoins;
    [SerializeField] private TMP_Text _textTimerPowerUpSpeed;
    [SerializeField] private TMP_Text _textTimerPowerUpImmortality;
    [SerializeField] private float _timePowerUpCoins = 10;
    [SerializeField] private float _timePowerUpSpeed = 10;
    [SerializeField] private float _timePowerUpImmortality = 10;
    [SerializeField] private float _timeLeftPowerUpCoins;
    [SerializeField] private float _timeLeftPowerUpSpeed;
    [SerializeField] private float _timeLeftPowerUpImmortality;
    private bool _isStartedPowerUpCoins;
    private bool _isStartedPowerUpSpeed;
    private bool _isStartedPowerUpImmortality;
    private ScoreManager _scoreManager;
    private DifficultyManager _difficultyManager;

    public bool PlayerIsImmortality { get; private set; }

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _difficultyManager = FindObjectOfType<DifficultyManager>();
    }

    private void Update()
    {
        if (_isStartedPowerUpCoins)
        {
            _timeLeftPowerUpCoins -= Time.deltaTime;
            _textTimerPowerUpCoins.text = ((int)_timeLeftPowerUpCoins).ToString();
            if (_timeLeftPowerUpCoins < 0) DisablePowerUpCoins();
        }

        if (_isStartedPowerUpSpeed)
        {
            _timeLeftPowerUpSpeed -= Time.deltaTime;
            _textTimerPowerUpSpeed.text = ((int)_timeLeftPowerUpSpeed).ToString();
            if (_timeLeftPowerUpSpeed < 0) DisablePowerUpSpeed();
        } 

        if (_isStartedPowerUpImmortality)
        {
            _timeLeftPowerUpImmortality -= Time.deltaTime;
            _textTimerPowerUpImmortality.text = ((int)_timeLeftPowerUpImmortality).ToString();
            if (_timeLeftPowerUpImmortality < 0) DisablePowerUpImmortality();
        }
    }

    public void EnablePowerUpCoins()
    {
        _scoreManager.SetBoost(true);
        _textTimerPowerUpCoins.gameObject.SetActive(true);
        _isStartedPowerUpCoins = true;
        _timeLeftPowerUpCoins = _timePowerUpCoins;
    }

    public void EnablePowerUpSpeed()
    {
        _difficultyManager.SetBoost(true);
        _textTimerPowerUpSpeed.gameObject.SetActive(true);
        _isStartedPowerUpSpeed = true;
        _timeLeftPowerUpSpeed = _timePowerUpSpeed;
    }

    public void EnablePowerUpImmortality()
    {
        PlayerIsImmortality = true;
        _textTimerPowerUpImmortality.gameObject.SetActive(true);
        _isStartedPowerUpImmortality = true;
        _timeLeftPowerUpImmortality = _timePowerUpImmortality;
    }

    private void DisablePowerUpCoins()
    {
        _scoreManager.SetBoost(false);
        _textTimerPowerUpCoins.gameObject.SetActive(false);
        _isStartedPowerUpCoins = false;
    } 

    private void DisablePowerUpSpeed()
    {
        _difficultyManager.SetBoost(false);
        _textTimerPowerUpSpeed.gameObject.SetActive(false);
        _isStartedPowerUpSpeed = false;
    } 
    
    private void DisablePowerUpImmortality()
    {
        PlayerIsImmortality = false;
        _textTimerPowerUpImmortality.gameObject.SetActive(false);
        _isStartedPowerUpImmortality = false;
    }
}