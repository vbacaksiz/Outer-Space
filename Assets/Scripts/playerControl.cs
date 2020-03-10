using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    Rigidbody physics;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float playerSpeed;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float gradient;
    float fireTime=0;
    public float fireTimeExp;
    public GameObject ammo;
    public Transform barrelTip;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        physics = GetComponent<Rigidbody>();
    }

    //Edit->Project Settings->Input->Fire1
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time>fireTime)
        {
            fireTime = Time.time + fireTimeExp;
            Instantiate (ammo, barrelTip.position, Quaternion.identity);
            audio.Play();
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal, 0, vertical);

        physics.velocity = vec*playerSpeed;

        physics.position = new Vector3
        (
                Mathf.Clamp(physics.position.x,minX,maxX),
            0.0f,
                Mathf.Clamp(physics.position.z,minZ,maxZ)
        );

        physics.rotation = Quaternion.Euler(0, 0, physics.velocity.x*-gradient);

    }
}
