using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class LeaderController : Grabber
{
    private Vector3 _dir;
    private int _followersAmount = 0;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _dir = Vector3.forward * movementSpeed;
    }

    public void Move(Vector3 dirNormalized)
    {
        if (dirNormalized != Vector3.zero)
        {
            _dir = dirNormalized * movementSpeed;
        }
        
        _characterController.Move(_dir * Time.deltaTime);
        
        transform.rotation = Quaternion.LookRotation(_dir);
    }

    public override void CheckForGrabbers()
    {
        Collider[] grabbers = Physics.OverlapSphere(transform.position, grabbingRange, layerMask);
        foreach (Collider c in grabbers)
        {
            Grabber grabber = c.GetComponent<Grabber>();
            if (grabber != null)
            {
                grabber.BeGrabbed(this);
            }
        }
    }

    public override void BeGrabbed(Grabber leader)
    {
        if (_followersAmount > 0) return;
        
        //TODO:: logic for loosing
    }

    public override int? GetFollowersAmount()
    {
        return _followersAmount;
    }
}
