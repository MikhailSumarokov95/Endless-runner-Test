using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void SetSound(bool isSound) => AudioListener.volume = isSound ? 1 : 0;
}
