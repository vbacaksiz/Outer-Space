﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidRotation : MonoBehaviour
{
    Rigidbody physics;
    public float speed;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.angularVelocity = Random.insideUnitSphere*speed;
    }


    
}
