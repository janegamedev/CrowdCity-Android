
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class FollowerController : Grabber
{
    public Events.EventFollowerGrabbed onFollowerGrabbed;
    public Vector3 target;
    public LeaderController leader;
    
    private NavMeshAgent _navMeshAgent;
    
    private void Awake()
    {
        canGrab = false;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        if (canGrab)
        {
            CheckForGrabbers();
        }
    }

    private void LateUpdate()
    {
        _navMeshAgent.SetDestination(target);
    }
    
    public bool IsAtDestination()
    {
        if ((transform.position - target).sqrMagnitude < 16)
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
                if (_grabber.BeGrabbed(leader))
                {
                    StartCoroutine(GrabDelay());
                    break;
                }
            }
        }
    }

    public override bool BeGrabbed(LeaderController l)
    {
        if (leader == null)
        {
            leader = l;
            leader.followersAmount++;
            onFollowerGrabbed?.Invoke();
            return true;
        }

        if(l == leader) return false;
            
        if((l.GetFollowersAmount() > leader.GetFollowersAmount()))
        {
            leader.followersAmount--;
            leader = l;
            leader.followersAmount++;
            onFollowerGrabbed?.Invoke();
            return true;
        }

        return false;
    }
}
