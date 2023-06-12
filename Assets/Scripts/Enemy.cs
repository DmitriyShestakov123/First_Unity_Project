using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private LayerMask _playerMask;

    [SerializeField]
    private LayerMask _default;

    [SerializeField]
    private float _sightRange;
    
    [SerializeField]
    private float _walkRange;

    // [SerializeField]
    // private GameObject _loseWindow;

    // [SerializeField]
    // private GameObject _winWindow;

    private NavMeshAgent _navMeshAgent;
    private Transform _transform;

    private void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _transform = transform;
    }

    private void Update() {
        if (IsPlayerInSight()) MoveToTarget(_playerTransform.position);
    }

    private void MoveToTarget(Vector3 target) {
        _navMeshAgent.SetDestination(target);
    }

    private bool IsPlayerInSight() {
        Vector3 direction = _playerTransform.position - _transform.position;

        Debug.DrawLine(_transform.position + Vector3.up, _transform.position + direction.normalized * _sightRange, Color.magenta);
        Debug.DrawLine(_transform.position + Vector3.up, _transform.position + direction.normalized * direction.magnitude, Color.blue);

        bool player = Physics.Raycast(_transform.position, direction, _sightRange, _playerMask);
        bool obstacle = Physics.Raycast(_transform.position, direction, direction.magnitude, ~_playerMask & ~_default);

        return player & !obstacle;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(_walkRange * 2, transform.position.y, _walkRange));
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
            Debug.Log(other.gameObject.tag);
            DataHolder.gameResult = 0;
            SceneManager.LoadScene("MainMenu");
    }
}
