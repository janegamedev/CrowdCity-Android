using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class WaypointNavigation : MonoBehaviour
{
    private CarNavigationController _carNavigationController;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        _carNavigationController = GetComponent<CarNavigationController>();
    }

    private void Start()
    {
        _carNavigationController.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (_carNavigationController.reachedDestination)
        {
            bool shouldBranch = false;

            if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRation ? true : false;
            }

            if (shouldBranch || currentWaypoint.nextWaypoint == null)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
            }
            else
            {
                currentWaypoint = currentWaypoint.nextWaypoint;
            }

            _carNavigationController.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
