using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimationCrashObstacle : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
