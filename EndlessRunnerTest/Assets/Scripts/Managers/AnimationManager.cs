using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private GameObject _firePickUpCoinPrefab;
    [SerializeField] private GameObject _firePickUpCoinBoostPrefab;
    [SerializeField] private GameObject _fireCrashObstaclePrefab;
    [SerializeField] private Animator _playerAnimator;

    public void PickUpCoin(Vector3 position)
    {
        Instantiate(_firePickUpCoinPrefab, position, _firePickUpCoinPrefab.transform.rotation);
    }

    public void PickUpCoinBoost(Vector3 position)
    {
        Instantiate(_firePickUpCoinBoostPrefab, position, _firePickUpCoinBoostPrefab.transform.rotation);
    }

    public void CrashObstacle(Vector3 position)
    {
        Instantiate(_fireCrashObstaclePrefab, position, _fireCrashObstaclePrefab.transform.rotation);
    }

    public void Jump()
    {
        _playerAnimator.SetTrigger("Jump");
    }
}
