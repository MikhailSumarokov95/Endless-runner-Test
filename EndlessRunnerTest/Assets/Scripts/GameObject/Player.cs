using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _translateRange = new Vector3(1.6f, 0, 0);
    [SerializeField] private float _powerJump = 5f;
    private Rigidbody _playerRigidbody;
    private ScoreManager _scoreManager;
    private UIManager _UIManager;
    private DifficultyManager _difficultyManager;
    private AnimationManager _animationManager;
    private SoundManager _soundManager;
    private bool _stayOnGround;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        _UIManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
        _difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        _animationManager = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationManager>();
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void MoveLeft()
    {
        if (!(transform.position.z > 0.1f))
        {
            transform.Translate(-_translateRange);
            _soundManager.Move();
        }
    }  

    public void MoveRight()
    {
        if (!(transform.position.z < -0.1f))
        {
            transform.Translate(_translateRange);
            _soundManager.Move();
        }
    }

    public void Jump()
    {
        if (_stayOnGround)
        {
            Debug.Log("Jump");
            _playerRigidbody.AddForce(Vector3.up * _powerJump, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter (Collider other)
    {

        if (other.gameObject.tag == "Coin")
        {
            _scoreManager.PickUpCoin();
            _animationManager.PickUpCoin(other.transform.position);
            _soundManager.PickUpCoin();

        }
        else if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            _UIManager.GameOver();
            _difficultyManager.GameOver();
            _animationManager.CrashObstacle(other.transform.position);
            _soundManager.CrashObstacle();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Road") _stayOnGround = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Road") _stayOnGround = false;
    }
}
