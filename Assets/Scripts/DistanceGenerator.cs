using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceGenerator : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface _navMeshSurface;

    private void Start() {
        _navMeshSurface.BuildNavMesh();
    }
}
