
using UnityEngine;
using UnityEngine.AI;

public class FollowerController : Grabber
{
    public Vector3 target;
    public Grabber leader;
    
    private NavMeshAgent _navMeshAgent;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            _navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        }
    }

    private void LateUpdate()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        _navMeshAgent.SetDestination(target);
    }

    public bool IsAtDestination()
    {
        return true;
    }

    
    public override void CheckForGrabbers()
    {
        Collider[] grabbers = Physics.OverlapSphere(transform.position, grabbingRange, layerMask);
        
        foreach (Collider grabber in grabbers)
        {
            Grabber _grabber = grabber.GetComponent<Grabber>();
            if (_grabber != null)
            {
                _grabber.BeGrabbed(leader);
            }
        }
    }

    public override void BeGrabbed(Grabber l)
    {
        if (l.GetFollowersAmount() > leader.GetFollowersAmount())
        {
            leader = l;
            //Change state 
        }
    }
}
