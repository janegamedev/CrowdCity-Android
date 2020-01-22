using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum State
{
    WONDERING, 
    FOLLOWING
}

public class Follower : MonoBehaviour
{
    public State followerState;
    private Vector3 _dir;
    private FollowerController _followerController;
    
    private void Awake()
    {
        _followerController = GetComponent<FollowerController>();
        followerState = State.WONDERING;
    }
    
    private void Update()
    {
        switch (followerState)
        {
            case State.WONDERING:
                if (_followerController.IsAtDestination())
                {
                    _dir = transform.position + Random.insideUnitSphere * Random.Range(10, 40);
                }
                break;
            
            case State.FOLLOWING:
                _dir = _followerController.leader.transform.position + (Vector3)Random.insideUnitCircle;
                _followerController.CheckForGrabbers();
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }

        _followerController.target = _dir;
    }

}
