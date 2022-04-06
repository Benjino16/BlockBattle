using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pathfinder), typeof(MovementController))]
public class FollowPath : MonoBehaviour
{
    [SerializeField] Pathfinder pathfinder;
    [SerializeField] MovementController movementController;
    [SerializeField] Transform target;
    [SerializeField] float updatePathTime = 1f;


    private void Start()
    {
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        pathfinder.FindPath(transform.position, target.position);
        yield return new WaitForSeconds(updatePathTime);
        StartCoroutine(UpdatePath());
    }

    private void OnValidate()
    {
        pathfinder = GetComponent<Pathfinder>();
        movementController = GetComponent<MovementController>();
    }
}
