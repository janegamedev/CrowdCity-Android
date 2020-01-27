using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public enum State
{
    WONDERING, 
    FOLLOWING
}

public class Follower : MonoBehaviour
{
    public State followerState;
    private Vector3 target;
    private FollowerController _followerController;
    
    private void Awake()
    {
        _followerController = GetComponent<FollowerController>();
        _followerController.onFollowerGrabbed.AddListener(ChangeState);
        followerState = State.WONDERING;
        _followerController.target = target = transform.position;
    }
    
    private void Update()
    {
        switch (followerState)
        {
            case State.WONDERING:
                if (_followerController.IsAtDestination())
                {
                    GetPointOnNavMesh(transform.position + Random.insideUnitSphere * Random.Range(20, 40));
                }
                break;
            
            case State.FOLLOWING:
                target = _followerController.leader.transform.position + Random.insideUnitSphere;
                _followerController.CheckForGrabbers();
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }

        target.y = 0;
        _followerController.target = target;
    }

    private void ChangeState()
    {
        followerState = State.FOLLOWING;
    }

    private void GetPointOnNavMesh(Vector3 _target)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(_target, out hit, 10.0f, NavMesh.AllAreas))
        {
            target = hit.position;
        }
    }
}
