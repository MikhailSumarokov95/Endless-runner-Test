using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _translateRange = new Vector3(1.6f, 0, 0);
    private float _powerJump = 1f;
    private Collision _playerCollision;
    private Rigidbody _playerRigidbody;
    private ScoreManager _scoreManager;
    private UIManager _UIManager;
    private DifficultyManager _difficultyManager;
    private AnimationManager _animationManager;

    private void Start()
    {
        //_playerCollision = GetComponent<Collision>();
        _playerRigidbody = GetComponent<Rigidbody>();
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        _UIManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
        _difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        _animationManager = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationManager>();

    }

    public void MoveLeft()
    {
        if (!(transform.position.z > 0.1f))
            transform.Translate(- _translateRange);
    }  

    public void MoveRight()
    {
        if (!(transform.position.z < - 0.1f))
            transform.Translate(_translateRange);
    }

    //public void Jump()
    //{
    //    if (_playerCollision.collider.tag == "Road")
    //        _playerRigidbody.AddForce(Vector3.up * _powerJump, ForceMode.Impulse);
    //}

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            _scoreManager.PickUpCoin();
            _animationManager.PickUpCoin(other.transform.position);
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            _UIManager.OnTableGameOver();
            _difficultyManager.GameOver();
            _animationManager.CrashObstacle(other.transform.position);
        }
    }
}
