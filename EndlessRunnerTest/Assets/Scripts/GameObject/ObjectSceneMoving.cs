using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSceneMoving: MonoBehaviour
{
    private DifficultyManager _difficultyManager;
    private float _difficulty;
    private float _speed = - 10;
    private float _coefficient—orrectiveDirection;

    private void OnEnable()
    {
        _difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        _difficulty = _difficultyManager.SpeedGame;
        if (transform.eulerAngles.y > 179) _coefficient—orrectiveDirection = -1;
        else _coefficient—orrectiveDirection = 1;
    }

    public virtual void Update()
    {
        _difficulty = _difficultyManager.SpeedGame;
        Move();
        if (transform.position.x < -50) Destroy(gameObject);
    }

    private void Move()
    {
        transform.Translate(Vector3.right * _coefficient—orrectiveDirection * _speed * _difficulty * Time.deltaTime);
    }
}
