using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class GrabberSpawner : MonoBehaviour
{
    public GameObject leader;
    public GameObject followerPrefab;
    
    public Collider[] spawnFollowerSpots;
    public Transform[] spawnLeaderSpots;

    public bool canSpawn;
    public float timeBetweenSpawn;
    public int spawnRadius;
    public int maxAmountWanderingOnScene;
    public int currentAmountWanderingOnScene;
    
    public void Update()
    {
        if (canSpawn && currentAmountWanderingOnScene < maxAmountWanderingOnScene)
        {
            SpawnFollower();
        }   
    }

    private void SpawnFollower()
    {
        Instantiate(followerPrefab, GetRandomPosition(), Quaternion.identity);
        currentAmountWanderingOnScene++;
        StartCoroutine(SpawnDelay());
    }

    private Vector3 GetRandomPosition()
    {
        int spotIndex = Random.Range(0, spawnFollowerSpots.Length);
        Collider randomSpawn = spawnFollowerSpots[spotIndex];

        return RandomPointInBounds(randomSpawn.bounds);
    }

    private static Vector3 RandomPointInBounds(Bounds bounds)
    {
        Vector3 random =  new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            0,
            Random.Range(bounds.min.z, bounds.max.z)
        );
        
        NavMeshHit hit;
        if (NavMesh.SamplePosition(random, out hit, 100.0f, NavMesh.AllAreas))
        {
            random = hit.position;
        }
        return random;
    }

    IEnumerator SpawnDelay()
    {
        canSpawn = false;
        
        yield return new WaitForSeconds(timeBetweenSpawn);
        
        canSpawn = true;
    }
}
