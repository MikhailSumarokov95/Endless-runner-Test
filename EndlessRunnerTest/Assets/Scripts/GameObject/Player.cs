using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _jumpAudio;
    [SerializeField] private GameObject _moveAudio;
    [SerializeField] private float _smoothMove = 3.5f;
    [SerializeField] private AnimationCurve _yPosition;
    [SerializeField] private bool _isJump;
    [SerializeField] private float _heightJump = 2f;
    [SerializeField] private float _timeJump = 1f;
    private float _jumpTime = 0;
    private Transform _target;
    private Vector3 _translateRange = new Vector3(0, 0, -1.6f);
    private Animator _playerAnimator;
    private ScoreManager _scoreManager;
    private DifficultyManager _difficultyManager;
    private StatusGameManager _statusGameManager;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _target = GameObject.FindGameObjectWithTag("TargetMovePlayer").transform;
        _scoreManager = FindObjectOfType<ScoreManager>();
        _difficultyManager = FindObjectOfType<DifficultyManager>();
        _statusGameManager = FindObjectOfType<StatusGameManager>();
    }

    private void Update()
    {
        _target.position = new Vector3(_target.position.x, transform.position.y, _target.position.z);
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _smoothMove);
        if (_isJump) Jumping();
    }

    public void MoveLeft()
    {
        if (!(_target.transform.position.z > 0.1f))
        {
            _target.transform.Translate(-_translateRange);
            PlayerSound(_moveAudio);
        }
    }  

    public void MoveRight()
    {
        if (!(_target.transform.position.z < -0.1f))
        {
            _target.transform.Translate(_translateRange);
            PlayerSound(_moveAudio);
        }
    }

    public void Jump()
    {
        if (!_isJump)
        {
            var jumpAudio = Instantiate(_jumpAudio);
            Destroy(jumpAudio, jumpAudio.GetComponent<AudioSource>().clip.length);
            _isJump = true;
            _playerAnimator.SetTrigger("Jump");
        }
    }

    private void Jumping()
    {
        _jumpTime += Time.deltaTime / _timeJump;
        transform.position = new Vector3(transform.position.x, _yPosition.Evaluate(_jumpTime) * 2 * _heightJump, transform.position.z);
        if (_jumpTime >= 1)
        {
            _isJump = false;
            _jumpTime = 0;
        }
    }

    private void PlayerSound(GameObject sound)
    {
        var soundObj = Instantiate(sound);
        Destroy(soundObj, soundObj.GetComponent<AudioSource>().clip.length);
    }

    private void OnTriggerEnter (Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                _scoreManager.PickUpCoin();
                break;

            case "Obstacle":
                Destroy(gameObject);
                _statusGameManager.GameOver();
                break;

            case "CoinBoost":
                _difficultyManager.SetBoost();
                break;
        }
    }
}
