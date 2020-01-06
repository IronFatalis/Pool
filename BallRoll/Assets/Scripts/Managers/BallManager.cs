using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float friction = 2;
    public float mass = 2;
    public float acceleration = 20;
    public float force = 1;
    public float velocity = 0;
    public float distance = 0;
    public float momentum = 0;
    int inverse = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            
            acceleration = mass * force;
            force = mass * acceleration;
            velocity = distance / Time.deltaTime;
            distance = velocity * Time.deltaTime;
            momentum = mass * velocity;
        }
        else if (!Input.GetMouseButton(0))
        {
            if (velocity >= 0.5)
            {
                velocity = velocity - (friction * (Time.deltaTime * 10));
            }
            else if (velocity <= -0.5)
            {
                velocity = velocity + (friction * (Time.deltaTime * 10));
            }
            else
            {
                velocity= 0;
            }
        }
        transform.Translate(Vector3.forward * (velocity * Time.deltaTime));
        //this.transform.Rotate(speed, 0, 0);

        if (this.transform.position.x >= 9 || this.transform.position.x <= -9)
        {
            //bounce without reflecting direction
            Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y * inverse, transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
            //Vector3 Bump1 = new Vector3(9,transform.position.y,transform.position.z);
        }
        else if (this.transform.position.z >= 19 || this.transform.position.z <= -19)
        {
            //reflects direction and bounce
            Quaternion rot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y * inverse, this.transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
            velocity = velocity * inverse;
        }

        print("Velocity");
        print(velocity);
    }
}
