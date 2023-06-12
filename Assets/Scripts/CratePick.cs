using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CratePick : MonoBehaviour
{

    [SerializeField]
    private Transform _player;

    //private bool _pickPressed = false;
    private bool _accessible;
    private bool _picked = false;
    private Transform _transform;
    private Vector3 _playerPosition;
    private Vector3 _currentMovement;
    private bool _touchingPlayer;
    private Vector3 _delta;

    private void Start() {
        _transform = transform;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            _accessible = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            _accessible = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext ctx) {
        if(_accessible) {
            if(ctx.performed && _picked == false) {
                _picked = true;
                Movement.maxSpeed *= 0.5f;
            }
            if(ctx.canceled && _picked == true) {
                _picked = false;
                Movement.maxSpeed *= 2f;
            }
        }
    }

    private void Update() {
        followPlayer();
    }

    void followPlayer() {
        if(_picked) {
            _playerPosition.Set(_player.position.x, _transform.position.y, _player.position.z);
            _delta = _playerPosition - _transform.position;
            if(_delta.magnitude > 1.4f) {
                _transform.position = Vector3.MoveTowards(_transform.position, _playerPosition, Movement.maxSpeed * Time.deltaTime);
            }
        }
    }
}
