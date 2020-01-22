
using UnityEngine;

public class Grabber: MonoBehaviour
{
    public float movementSpeed;
    
    public float grabbingRange;
    public LayerMask layerMask;
    
    public virtual void CheckForGrabbers()
    {
       
    }

    public virtual void BeGrabbed(Grabber l)
    {
        
    }

    public virtual int? GetFollowersAmount()
    {
        return null;
    }
}
