using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _translateRange = new Vector3(1.6f, 0, 0);
    private float _powerJump = 5f;
    private Rigidbody _playerRigidbody;
    private AnimationManager _animationManager;
    private SoundManager _soundManager;
    private EventManager _eventManager;
    private bool _stayOnGround;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _animationManager = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationManager>();
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
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
            _playerRigidbody.AddForce(Vector3.up * _powerJump, ForceMode.Impulse);
            _animationManager.Jump();
        }
    }

    private void OnTriggerEnter (Collider other)
    {

        if (other.gameObject.tag == "Coin")
        {
            _eventManager.PickUpCoin(other.transform.position);
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            _eventManager.CrushObstacle(other.transform.position);
        }

        else if (other.gameObject.tag == "CoinBoost")
        {
            _eventManager.PickUpCoinBoost(other.transform.position);
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
