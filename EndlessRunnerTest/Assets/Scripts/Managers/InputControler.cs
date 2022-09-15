using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControler : MonoBehaviour
{ 
    private Player _player;
    private SpawnManager _spawnManager;

    private void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        _spawnManager.onCreateCharacter += InitializedCharacter;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) _player.MoveLeft();
        else if (Input.GetKeyDown(KeyCode.RightArrow)) _player.MoveRight();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _player.Jump();
    }

    private void InitializedCharacter(GameObject character)
    {
        _player = character.GetComponent<Player>();
    }
}
