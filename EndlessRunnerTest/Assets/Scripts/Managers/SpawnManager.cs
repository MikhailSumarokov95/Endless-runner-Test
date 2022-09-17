using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToxicFamilyGames.MenuEditor;
using System;

public class SpawnManager : MonoBehaviour, IShoper
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _coinBoost;
    [SerializeField] private GameObject[] _environment;
    [SerializeField] private GameObject[] _obstacls;
    private GameObject _characterSkinSelected;
    private GameObject _characterPlayer;
    private DifficultyManager _difficultyManager;
    private StatusGameManager _statusGameManager;
    private Vector3 _spawnPointCharacter = new Vector3(7f, 0.3f, 0f);
    private Vector3 _spawnPointCoin = new Vector3(149f, 1f, 0);
    private Vector3 _spawnPointObstacle = new Vector3(149f, 0f, 0);
    private float[] _spawnPointZCoinAndObtacle = new float[] { 1.6f, 0, -1.6f };
    private Vector3 _spawnPointEnvironmentLeft = new Vector3(149f, 0, 7f);
    private Vector3 _spawnPointEnvironmentRight = new Vector3(149f, 0, -7f);

    private void Awake()
    {
        _difficultyManager = FindObjectOfType<DifficultyManager>();
        _statusGameManager = FindObjectOfType<StatusGameManager>();
        _statusGameManager.onPausedGame += StopSpawn;
        _statusGameManager.onStartedGame += StartSpawn;
    }

    public void OnSelectCharacter(GameObject characterSkinSelected)
    {
        _characterSkinSelected = characterSkinSelected;
    }

    public void CreateCharacter()
    {
        if (_characterPlayer != null) Destroy(_characterPlayer);
        _characterPlayer = Instantiate(_characterSkinSelected, _spawnPointCharacter, _characterSkinSelected.transform.rotation);
    }

    private void StopSpawn() => StopAllCoroutines();

    private void StartSpawn()
    {
        StartCoroutine(SpawnEnvironmentObject());
        StartCoroutine(SpawnCoins());
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnBonus());
    }

    IEnumerator SpawnEnvironmentObject()
    {
        while(true)
        {
            yield return new WaitForSeconds(1 / _difficultyManager.SpeedGame);
            int numberEnvironment = UnityEngine.Random.Range(0, _environment.Length);
            Instantiate(_environment[numberEnvironment], _spawnPointEnvironmentLeft, Quaternion.Euler(0, 180, 0));
            Instantiate(_environment[numberEnvironment], _spawnPointEnvironmentRight, _environment[numberEnvironment].transform.rotation);
        }
    }

    IEnumerator SpawnCoins()
    {
        while(true)
        {
            yield return new WaitForSeconds(1 / _difficultyManager.SpeedGame);
            _spawnPointCoin.z = _spawnPointZCoinAndObtacle[UnityEngine.Random.Range(0, 3)];
            Instantiate(_coin, _spawnPointCoin, _coin.transform.rotation);
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2 / _difficultyManager.SpeedGame);
            _spawnPointObstacle.z = _spawnPointZCoinAndObtacle[UnityEngine.Random.Range(0, 3)];
            int numberObstacle = UnityEngine.Random.Range(0, _obstacls.Length);
            Instantiate(_obstacls[numberObstacle], _spawnPointObstacle, _obstacls[numberObstacle].transform.rotation);
        }
    }

    IEnumerator SpawnBonus()
    {
        while (true)
        {
            yield return new WaitForSeconds(20 / _difficultyManager.SpeedGame);
            _spawnPointCoin.z = _spawnPointZCoinAndObtacle[UnityEngine.Random.Range(0, 3)];
            Instantiate(_coinBoost, _spawnPointCoin, _coinBoost.transform.rotation);
        }
    }
}