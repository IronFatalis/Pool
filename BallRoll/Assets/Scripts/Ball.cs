﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float b_fric = 2;
    public float b_ma = 2;
    private float b_accel = 0;
    public float b_for = 1;
    public float b_velo = 0;
    public float b_dist = 0;
    public float b_momen = 0;
    public float inverse = -1;
    int bumperSize = 1;
    int ballSize = 1;
    public float b_radius = 0.5f;
    Bounds b;

    private GameObject bumperLeft;
    private GameObject bumperRight;
    private GameObject bumperTop;
    private GameObject bumperBottom;

    private Ball(float b_velocity)
    {
        this.b_velo = b_velocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        b_accel = b_ma * b_for;
        //force = mass * acceleration;
        b_velo = b_accel / Time.deltaTime;
        //distance = velocity * Time.deltaTime;
        b_momen = b_ma * b_velo;

        b = new Bounds(new Vector3(0, 0, 0), new Vector3(2, 2, 2));

        bumperLeft = GameObject.Find("BumperLeft");
        bumperRight = GameObject.Find("BumperRight");
        bumperTop = GameObject.Find("BumperTop");
        bumperBottom = GameObject.Find("BumperBottom");
    }

    // Update is called once per frame
    void Update()
    {
        B_Collide();
    }

    void B_Collide()
    {
        
        //colliding with rails
        if (transform.position.x <= bumperLeft.transform.position.x + bumperSize || transform.position.x >= bumperRight.transform.position.x - bumperSize)
        {
            //bounce without reflecting direction
            Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y * inverse, transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
        }
        else if (transform.position.z >= bumperTop.transform.position.z - bumperSize || transform.position.z <= bumperBottom.transform.position.z + bumperSize)
        {
            //reflects direction and bounce
            Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y * inverse, transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
        }
    }
}

