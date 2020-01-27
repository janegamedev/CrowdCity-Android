
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber: MonoBehaviour
{
    public float movementSpeed;

    public bool canGrab;
    public float grabbingRange;
    public float grabDelay;
    public LayerMask layerMask;
    
    public virtual void CheckForGrabbers()
    {
       
    }

    public virtual bool BeGrabbed(LeaderController l)
    {
        return true;
    }

    protected IEnumerator GrabDelay()
    {
        canGrab = false;        
        yield return new WaitForSeconds(grabDelay);
        canGrab = true;
    }

    public virtual int? GetFollowersAmount()
    {
        return null;
    }
}
