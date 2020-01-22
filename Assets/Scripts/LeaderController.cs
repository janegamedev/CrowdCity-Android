using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderController : MonoBehaviour , IGrabber
{
    public float movementSpeed;

    private int _followersAmount;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
        {
            _characterController = gameObject.AddComponent<CharacterController>();
        }
    }

    public void Move(Vector3 dirNormalized)
    {
        _characterController.Move(dirNormalized * movementSpeed);
    }

    public void CheckForGrabbers()
    {
        throw new System.NotImplementedException();
    }

    public void Grab(IGrabber grabber)
    {
        throw new System.NotImplementedException();
    }

    public void BeGrabbed()
    {
        throw new System.NotImplementedException();
    }
}
