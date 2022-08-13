using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private DifficultyManager _difficultyManager;
    private int _difficulty;
    private float _speed = - 10;

    private void Start()
    {
        _difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        _difficulty = _difficultyManager.SpeedGame;        
    }

    public virtual void Update()
    {
        _difficulty = _difficultyManager.SpeedGame;
        Move();
        if (transform.position.x < -50) Destroy(gameObject);
    }

    private void Move()
    {
        transform.Translate(_speed * _difficulty * Time.deltaTime, 0, 0);
    }
}
