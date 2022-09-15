using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatusGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private GameObject _buttonGoMenu;
    [SerializeField] private Button _buttonStartFromMenu;
    [SerializeField] private GameObject _audioGameOver;
    public Action onStartedGame;
    public Action onPausedGame;
    public Action onRestartedGame;
    private static bool _thisIsRestartGame;

    private void Start()
    {
        if (_thisIsRestartGame)
        {
            _panelMenu.SetActive(false);
            _buttonGoMenu.SetActive(true);
            _buttonStartFromMenu.onClick?.Invoke();
            _thisIsRestartGame = false;
        }
        else PauseGame();
    }

    public void StartGame()
    {
        onStartedGame?.Invoke();
    }

    public void PauseGame()
    {
        onPausedGame?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        _thisIsRestartGame = true; 
    }

    public void GameOver()
    {
        onPausedGame?.Invoke();
        var audioGameOver = Instantiate(_audioGameOver);
        Destroy(audioGameOver, audioGameOver.GetComponent<AudioSource>().clip.length);
        _panelGameOver.SetActive(true);
    }
}
