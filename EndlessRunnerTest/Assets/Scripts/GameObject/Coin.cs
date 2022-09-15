using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ObjectSceneMoving
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _soundPickUp;
    [SerializeField] private GameObject _firePickUpCoin;

    public override void Update()
    {
        base.Update();
        CoinRotate();
    }

    private void CoinRotate()
    {
        _coin.transform.Rotate(new Vector3(0, 100f * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var soundPickUp = Instantiate(_soundPickUp);
            Destroy(soundPickUp, soundPickUp.GetComponent<AudioSource>().clip.length);
            var firePickUpCoin = Instantiate(_firePickUpCoin, transform.position, Quaternion.identity);
            Destroy(firePickUpCoin, 0.3f);
            Destroy(gameObject);
        }
    }
}
