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
        _followerController.target = transform.position;
    }
    
    private void Update()
    {
        switch (followerState)
        {
            case State.WONDERING:
                if (_followerController.IsAtDestination())
                {
                    _dir = transform.position +  Random.insideUnitSphere * Random.Range(5, 10);
                }
                break;
            
            case State.FOLLOWING:
                _dir = _followerController.leader.transform.position + ( Random.insideUnitSphere);
                _followerController.CheckForGrabbers();
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }

        _dir.y = 0;
        _followerController.target = _dir;
    }
    
    

}
