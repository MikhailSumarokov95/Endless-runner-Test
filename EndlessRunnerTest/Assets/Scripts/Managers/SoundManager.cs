using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void SetActiveSound() => AudioListener.pause = !AudioListener.pause;
}
