using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigationController : MonoBehaviour
{
    /*private Rigidbody _rigidbody;*/

    public Vector3 destination;
    public float speed;
    public float stoppingDistance;
    public bool reachedDestination;

    /*private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }*/

    private void Update()
    {
        if ((transform.position - destination).sqrMagnitude < stoppingDistance * stoppingDistance)
        {
            reachedDestination = true;
        }
        
        if (!reachedDestination)
        {
            /*transform.LookAt(_destination);*/
            transform.Translate((transform.position - destination).normalized * (speed * Time.deltaTime), transform);
            /*_rigidbody.velocity = ( _destination - transform.position).normalized * speed;*/
            /*_rigidbody.AddForce(transform.forward * speed);*/
        }
    }

    public void SetDestination(Vector3 position)
    {
        destination = position;
        reachedDestination = false;
    }
    
    
}
