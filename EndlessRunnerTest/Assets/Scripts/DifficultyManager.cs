using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private int _difficulty = 1;

    public int SpeedGame
    {
        get { return _difficulty; } 
    }

    public void GameOver()
    {
        _difficulty = 0;
    }
}
