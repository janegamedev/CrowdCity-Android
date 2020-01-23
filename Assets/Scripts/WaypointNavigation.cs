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

    public void Init(Waypoint point)
    {
        currentWaypoint = point;
        _carNavigationController.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (_carNavigationController.reachedDestination)
        {
            if (currentWaypoint.nextWaypoint == null && currentWaypoint.branches != null)
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
