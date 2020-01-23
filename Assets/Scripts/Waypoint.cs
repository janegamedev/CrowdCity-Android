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

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
