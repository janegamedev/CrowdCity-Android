using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    public void SetTarget(Transform t)
    {
        target = t;
    }

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
