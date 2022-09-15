using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSceneMoving: MonoBehaviour
{
    private DifficultyManager _difficultyManager;
    private StatusGameManager _statusGameManager;
    private float _difficulty;
    private float _speed = - 10;
    private float _coefficient—orrectiveDirection;
    private bool _isMoveStoped;


    private void Awake()
    {
        _statusGameManager = FindObjectOfType<StatusGameManager>();
        _statusGameManager.onPausedGame += StopMove;
        _statusGameManager.onStartedGame += StartMove;
        _difficultyManager = FindObjectOfType<DifficultyManager>();
        _difficulty = _difficultyManager.SpeedGame;
        if (transform.eulerAngles.y > 179) _coefficient—orrectiveDirection = -1;
        else _coefficient—orrectiveDirection = 1;
    }

    public virtual void Update()
    {
        _difficulty = _difficultyManager.SpeedGame;
        if (!_isMoveStoped) Move();
        if (transform.position.x < -50) Destroy(gameObject);
    }

    private void Move()
    {
        transform.Translate(Vector3.right * _coefficient—orrectiveDirection * _speed * _difficulty * Time.deltaTime);
    }

    private void StopMove() => _isMoveStoped = true;

    private void StartMove() => _isMoveStoped = false;
}
