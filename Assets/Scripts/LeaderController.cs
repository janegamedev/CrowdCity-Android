using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class LeaderController : Grabber
{
    private Vector3 _dir;
    public int followersAmount = 0;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _dir = Vector3.forward * movementSpeed;
        canGrab = true;
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

    private void Update()
    {
        if (canGrab)
        {
            CheckForGrabbers();
        }
    }

    public override void CheckForGrabbers()
    {
        Collider[] grabbers = Physics.OverlapSphere(transform.position, grabbingRange, layerMask);
        foreach (Collider c in grabbers)
        {
            Grabber grabber = c.GetComponent<Grabber>();
            if (grabber != null)
            {
                if (grabber.BeGrabbed(this))
                {
                    StartCoroutine(GrabDelay());
                    break;
                }
            }
        }
    }

    public override bool BeGrabbed(LeaderController leader)
    {
        if (followersAmount > 0) return false;

        //TODO:: logic for loosing
        return true;
    }

    public override int? GetFollowersAmount()
    {
        return followersAmount;
    }
}
