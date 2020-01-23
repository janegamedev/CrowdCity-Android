
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class FollowerController : Grabber
{
    public Vector3 target;
    public Grabber leader;
    
    private NavMeshAgent _navMeshAgent;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void LateUpdate()
    {
        _navMeshAgent.SetDestination(target);
    }
    
    public bool IsAtDestination()
    {
        if ((transform.position - target).sqrMagnitude < 9)
        {
            return true;
        }
        
        return false;
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
        if(l == leader) return;
        
        if (l.GetFollowersAmount() > leader.GetFollowersAmount())
        {
            leader = l;
            //Change state 
        }
    }
}
