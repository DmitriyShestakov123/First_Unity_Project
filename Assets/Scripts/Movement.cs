using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public static float maxSpeed;

    [SerializeField]
    private float _maxSpeed;
    
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private float _inertiaModifier;

    private Vector2 _moveInput;
    private Vector2 _lerpedMoveInput;
    private Vector3 _currentMovement;
    private Transform _transform;

    private void Awake() {
        _transform = transform;
        maxSpeed = _maxSpeed;
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        if(ctx.performed) {
            _moveInput = ctx.ReadValue<Vector2>();
        }
        else {
            _moveInput = Vector2.zero;
        }
    }

    private void FixedUpdate() {
        Move();
        _maxSpeed = maxSpeed;
    }

    private void Move() {
        _lerpedMoveInput = Vector2.MoveTowards(_lerpedMoveInput, _moveInput, _inertiaModifier * Time.fixedDeltaTime);
        _currentMovement.Set(_lerpedMoveInput.x, 0, _lerpedMoveInput.y);
        _currentMovement = _transform.TransformVector(_currentMovement) * _maxSpeed;
        _characterController.Move(_currentMovement * Time.fixedDeltaTime);
    }
}
