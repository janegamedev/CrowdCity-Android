using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
            /*transform.Translate((transform.position - destination).normalized * (speed * Time.deltaTime), transform);*/
            /*_rigidbody.velocity = ( _destination - transform.position).normalized * speed;*/
            /*_rigidbody.AddForce(transform.forward * speed);*/
            
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
            //transform.LookAt(destination);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(destination - transform.position, Vector3.up), 5 * Time.deltaTime);
            /*transform.rotation = Quaternion.Euler(destination);*/
        }
    }

    public void SetDestination(Vector3 position)
    {
        destination = position;
        reachedDestination = false;
    }
    
    
}
