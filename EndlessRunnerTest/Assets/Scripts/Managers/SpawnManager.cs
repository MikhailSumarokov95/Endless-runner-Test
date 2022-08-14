using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _roadPrefab;
    [SerializeField] private GameObject _road;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject[] _environment;
    [SerializeField] private GameObject[] _obstacls;
    private DifficultyManager _difficultyManager;
    private Vector3 _spawnPointRoad = new Vector3(149f, 0, 0);
    private Vector3 _spawnPointCoin = new Vector3(149f, 1f, 0);
    private Vector3 _spawnPointObstacle = new Vector3(149f, 0f, 0);
    private float[] _spawnPointZCoinAndObtacle = new float[] { 1.6f, 0, -1.6f };
    private Vector3 _spawnPointEnvironmentLeft = new Vector3(149f, 0, 7.5f);
    private Vector3 _spawnPointEnvironmentRight = new Vector3(149f, 0, -7f);


    private void Start()
    {
        _difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        StartCoroutine(SpawnEnvironmentObject());
        StartCoroutine(SpawnCoins());
        StartCoroutine(SpawnObstacle());
    }

    private void Update()
    {
        if (_road.transform.position.x < 50) SpawnRoadAndGrass();
        if (_difficultyManager.SpeedGame == 0) StopAllCoroutines();
    }

    private void SpawnRoadAndGrass()
    {
        _road = Instantiate(_roadPrefab, _spawnPointRoad, _roadPrefab.transform.rotation);
    }

    IEnumerator SpawnEnvironmentObject()
    {

        while(true)
        {
            yield return new WaitForSeconds(1 / _difficultyManager.SpeedGame);
            int numberEnvironment = Random.Range(0, _environment.Length);
            Instantiate(_environment[numberEnvironment], _spawnPointEnvironmentLeft, _environment[numberEnvironment].transform.rotation);
            Instantiate(_environment[numberEnvironment], _spawnPointEnvironmentRight, _environment[numberEnvironment].transform.rotation);
        }
    }

    IEnumerator SpawnCoins()
    {
        while(true)
        {
            yield return new WaitForSeconds(1 / _difficultyManager.SpeedGame);
            _spawnPointCoin.z = _spawnPointZCoinAndObtacle[Random.Range(0, 3)];
            Instantiate(_coin, _spawnPointCoin, _coin.transform.rotation);
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2 / _difficultyManager.SpeedGame);
            _spawnPointObstacle.z = _spawnPointZCoinAndObtacle[Random.Range(0, 3)];
            int numberObstacle = Random.Range(0, _obstacls.Length);
            Instantiate(_obstacls[numberObstacle], _spawnPointObstacle, _obstacls[numberObstacle].transform.rotation);
        }
    }
}