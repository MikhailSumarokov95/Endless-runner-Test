using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBoost : ObjectSceneMoving
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _soundPickUpCoinBoost;
    [SerializeField] private GameObject _firePickUpCoinBoost;

    public override void Update()
    {
        base.Update();
        CoinRotate();
    }

    private void CoinRotate()
    {
        _coin.transform.Rotate(new Vector3(0, 300f * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var soundpickUpCoinBoost = Instantiate(_soundPickUpCoinBoost);
            Destroy(soundpickUpCoinBoost, soundpickUpCoinBoost.GetComponent<AudioSource>().clip.length);
            var firePickUpCoinBoost = Instantiate(_firePickUpCoinBoost, transform.position, Quaternion.identity);
            Destroy(firePickUpCoinBoost, 0.3f);
            Destroy(gameObject);
        }
    }
}
