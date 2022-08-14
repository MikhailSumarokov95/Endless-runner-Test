using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ObjectSceneMoving
{
    [SerializeField] private GameObject _coin;

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
        if (other.gameObject.tag == "Player") Destroy(gameObject);
    }
}
