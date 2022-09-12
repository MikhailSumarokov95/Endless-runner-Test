using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text _textCoins;
    [SerializeField] GameObject _tableGameOver;
    [SerializeField] TMP_Text _textTopCoinsScore;

    public void SetTextCoins(int coins)
    {
        _textCoins.text = coins.ToString();
    }

    public void SetTopCoinsScore(int topCoins)
    {
        _textTopCoinsScore.text = "Record: " + topCoins;
    }

    public void GameOver()
    {
        _tableGameOver.SetActive(true);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}