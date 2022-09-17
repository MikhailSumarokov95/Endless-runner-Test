using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToxicFamilyGames.AdsBrowser;

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
    private InputControlerMobile _inputControlerMobile;
    private InputControlerPC _inputControlerPC;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("TargetMovePlayer").transform;
        _playerAnimator = GetComponent<Animator>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _difficultyManager = FindObjectOfType<DifficultyManager>();
        _statusGameManager = FindObjectOfType<StatusGameManager>();
        if (YandexSDK.instance.isMobile()) FollowActionInputMobile();
        else FollowActionInputPC();
    }

    private void Update()
    {
        _target.position = new Vector3(_target.position.x, transform.position.y, _target.position.z);
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _smoothMove);
        if (_isJump) Jumping();
    }

    public void MoveLeft()
    {
        print("MoveLeft");
        if (!(_target.transform.position.z > 0.1f))
        {
            _target.transform.Translate(-_translateRange);
            PlayerSound(_moveAudio);
        }
    }  

    public void MoveRight()
    {
        print("MoveRight");
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

    private void FollowActionInputMobile()
    {
        print("FollowActionInputMobile");
        _inputControlerMobile = FindObjectOfType<InputControlerMobile>();
        _inputControlerMobile.onJump += Jump;
        _inputControlerMobile.onMoveLeft += MoveLeft;
        _inputControlerMobile.onMoveRight += MoveRight;
    }

    private void FollowActionInputPC()
    {
        print("FollowActionInputPC");
        _inputControlerPC = FindObjectOfType<InputControlerPC>();
        _inputControlerPC.onJump += Jump;
        _inputControlerPC.onMoveLeft += MoveLeft;
        _inputControlerPC.onMoveRight += MoveRight;
    }

    private void OnDestroy()
    {
        if (_inputControlerPC != null)
        {
            _inputControlerPC.onJump -= Jump;
            _inputControlerPC.onMoveLeft -= MoveLeft;
            _inputControlerPC.onMoveRight -= MoveRight;
        }
        if (_inputControlerMobile != null)
        {
            _inputControlerMobile.onJump -= Jump;
            _inputControlerMobile.onMoveLeft -= MoveLeft;
            _inputControlerMobile.onMoveRight -= MoveRight;
        }
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
