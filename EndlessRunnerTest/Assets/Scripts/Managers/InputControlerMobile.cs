using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputControlerMobile : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler
{
    [SerializeField] float rangePointerMoveForAction = 50f;
    public Action onJump;
    public Action onMoveLeft;
    public Action onMoveRight;
    private bool _isPress;
    private Vector2 _positionPointer;
    private Vector2 _startingPosition;

    private void Update()
    {
        if (_isPress) FollowPointer();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPress = true;
        _startingPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPress = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        _positionPointer = eventData.position;
    }

    private void FollowPointer()
    {
        if (_startingPosition.y - _positionPointer.y < - rangePointerMoveForAction)
        {
            onJump?.Invoke();
            _isPress = false;
        }
        else if (_startingPosition.x - _positionPointer.x < - rangePointerMoveForAction)
        {
            onMoveRight?.Invoke();
            _isPress = false;
        }
        else if (_startingPosition.x - _positionPointer.x > rangePointerMoveForAction)
        {
            onMoveLeft?.Invoke();
            _isPress = false;
        }
    }
}
