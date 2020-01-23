using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CarSpawner : MonoBehaviour
{
    public Transform carRoot;
    public GameObject[] carPrefabs;
    public int carAmount;
    private Waypoint[] waypoints;

    private void Start()
    {
        waypoints = FindObjectsOfType<Waypoint>();
        SpawnCars();
    }

    private void SpawnCars()
    {
        for (int i = 0; i < carAmount; i++)
        {
            Waypoint randomWaypoint = waypoints[Random.Range(0, waypoints.Length - 1)];
            GameObject carPrefab = carPrefabs[Random.Range(0, carPrefabs.Length - 1)];
            GameObject car = Instantiate(carPrefab, randomWaypoint.transform.position, randomWaypoint.transform.rotation, carRoot);
            car.GetComponent<WaypointNavigation>().Init(randomWaypoint);
        }
    }
}
