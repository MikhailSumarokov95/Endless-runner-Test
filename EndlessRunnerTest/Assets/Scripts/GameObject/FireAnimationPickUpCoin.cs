using System.Collections;
using UnityEngine;

public class FireAnimationPickUpCoin : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
