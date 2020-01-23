using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigationController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private Vector3 _destination;
    public float speed;
    public float stoppingDistance;
    public bool reachedDestination;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if ((transform.position - _destination).sqrMagnitude < stoppingDistance * stoppingDistance)
        {
            reachedDestination = true;
        }
        
        if (!reachedDestination)
        {
            transform.LookAt(_destination);
            _rigidbody.velocity = ( _destination - transform.position).normalized * speed;
            /*_rigidbody.AddForce(transform.forward * speed);*/
        }
    }

    public void SetDestination(Vector3 position)
    {
        _destination = position;
        reachedDestination = false;
    }
    
    
}
