using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : ObjectSceneMoving
{
    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(gameObject);
        }
    }
}
