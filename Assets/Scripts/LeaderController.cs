using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class LeaderController : Grabber
{
    private int _followersAmount = 0;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 dirNormalized)
    {
        dirNormalized *= movementSpeed;
        _characterController.Move(dirNormalized * Time.deltaTime);
        
        if (dirNormalized != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(dirNormalized);
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
