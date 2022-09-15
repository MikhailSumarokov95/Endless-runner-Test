using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : ObjectSceneMoving
{
    [SerializeField] GameObject _soundCrashObstacle;
    [SerializeField] private GameObject _fireCrashObstacle;

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Coin") Destroy(gameObject);
        else if (other.gameObject.tag == "Player")
        {
            var soundCrashObstacle = Instantiate(_soundCrashObstacle);
            Destroy(soundCrashObstacle, soundCrashObstacle.GetComponent<AudioSource>().clip.length);
            var fireCrashObstacle = Instantiate(_fireCrashObstacle, transform.position, Quaternion.identity);
            Destroy(fireCrashObstacle, 2);
        }
    }
}
