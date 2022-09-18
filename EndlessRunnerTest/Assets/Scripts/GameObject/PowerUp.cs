using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : ObjectSceneMoving
{
    [SerializeField] private GameObject _soundPickUpPowerUp;
    [SerializeField] private GameObject _firePickUpPowerUp;

    public override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var soundpickUpCoinBoost = Instantiate(_soundPickUpPowerUp);
            Destroy(soundpickUpCoinBoost, soundpickUpCoinBoost.GetComponent<AudioSource>().clip.length);
            var firePickUpCoinBoost = Instantiate(_firePickUpPowerUp, transform.position, Quaternion.identity);
            Destroy(firePickUpCoinBoost, 0.3f);
            Destroy(gameObject);
        }
    }
}
