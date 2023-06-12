using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionZone : MonoBehaviour
{

    [SerializeField]
    private Transform _target;
    private Transform _transform;

    private void Start() {
        _transform = transform;
    }

    private void FixedUpdate() {
        _transform.position = _target.position;
    }
}
