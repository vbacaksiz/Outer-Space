using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxControl : MonoBehaviour
{
    Rigidbody physics;
    public float fxSpeed;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.velocity = transform.forward*fxSpeed;
    }
    
}
