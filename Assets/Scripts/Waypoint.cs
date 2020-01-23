using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint previousWaypoint;
    public Waypoint nextWaypoint;

    [Range(5f, 15f)] 
    public float width = 5f;

    public List<Waypoint> branches = new List<Waypoint>();
    [Range(0f,1f)]
    public float branchRation = 0.5f;

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
