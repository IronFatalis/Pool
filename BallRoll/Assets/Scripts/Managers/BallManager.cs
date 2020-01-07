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
    float ballSize = 1;

    int inverse = -1;
    int bumperSize = 1;
    private GameObject bumperLeft;
    private GameObject bumperRight;
    private GameObject bumperTop;
    private GameObject bumperBottom;
    private GameObject CueBall;
    private GameObject Ball1;

    // Start is called before the first frame update
    void Start()
    {
        bumperLeft = GameObject.Find("BumperLeft");
        bumperRight = GameObject.Find("BumperRight");
        bumperTop = GameObject.Find("BumperTop");
        bumperBottom = GameObject.Find("BumperBottom");
        CueBall = GameObject.Find("CueBall");
        Ball1 = GameObject.Find("Balls");

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
            //force = mass * acceleration;
            velocity = acceleration / Time.deltaTime;
            //distance = velocity * Time.deltaTime;
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
                velocity = 0;
            }
        }

        transform.Translate(Vector3.forward * (velocity * Time.deltaTime));
        //this.transform.Rotate(speed, 0, 0);

        if (this.transform.position.x <= bumperLeft.transform.position.x + bumperSize || this.transform.position.x >= bumperRight.transform.position.x - bumperSize)
        {
            //bounce without reflecting direction
            Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y * inverse, transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
        }
        else if (this.transform.position.z >= bumperTop.transform.position.z - bumperSize || this.transform.position.z <= bumperBottom.transform.position.z + bumperSize)
        {
            //reflects direction and bounce
            Quaternion rot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y * inverse, this.transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
            velocity = velocity * inverse;
        }

        //print("Velocity");
        //print(velocity);

    }

    //sphere on sphere collision

}
