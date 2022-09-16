using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControlerPC : MonoBehaviour
{
    public Action onJump;
    public Action onMoveLeft;
    public Action onMoveRight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) onMoveLeft?.Invoke();
        else if (Input.GetKeyDown(KeyCode.RightArrow)) onMoveRight?.Invoke();
        else if (Input.GetKeyDown(KeyCode.Space)) onJump?.Invoke();
    }
}
