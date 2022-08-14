using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _moveAudio;
    [SerializeField] AudioSource _crashAudio;
    [SerializeField] AudioSource _PickUpAudio;
    [SerializeField] AudioSource _PickUpBoostAudio;

    public void Move()
    {
        _moveAudio.Play();        
    }

    public void CrashObstacle()
    {
        _crashAudio.Play();
    }

    public void PickUpCoin()
    {
        _PickUpAudio.Play();
    }  
    
    public void PickUpCoinBoost()
    {
        _PickUpBoostAudio.Play();
    }
}
