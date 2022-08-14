using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textCoins;
    [SerializeField] GameObject _tableGameOver;
    [SerializeField] Button _restartButton;
    [SerializeField] TextMeshProUGUI _textTopCoinsScore;
    [SerializeField] private GameObject _coin;

    private void Update()
    {
        CoinRotate();
    }

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
        _restartButton.onClick.AddListener(ReloadScene);
    }

    private void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void CoinRotate()
    {
        _coin.transform.Rotate(new Vector3(0, 100f * Time.deltaTime, 0));
    }
}