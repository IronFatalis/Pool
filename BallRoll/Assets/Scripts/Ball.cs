using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float friction = 2; //friction
    public float mass = 2; //mass
    public float acceleration = 0; //acceleration
    public float force = 1; //force
    public float velocity = 0; //velocity
    public float distance = 0; //unused
    public float momentum = 0; //momentum
    public float inverse = -1;
    int bumperSize = 1;
    int ballSize = 1;
    public float b_radius = 0.5f;
    Bounds b;
    bool hit = false;
    public Transform target;

    private GameObject bumperLeft;
    private GameObject bumperRight;
    private GameObject bumperTop;
    private GameObject bumperBottom;
    private GameObject CueBall, Ball1;
    Collider m_Collider1, m_Collider2;
    private Vector3 center;
    private Vector3 center2;
    private Vector3 targetDir;
    private Vector3 forward;

    // Start is called before the first frame update
    void Start()
    {
        acceleration = mass * force;
        velocity = acceleration / Time.deltaTime;
        momentum = mass * velocity;

        b = new Bounds(new Vector3(0, 0, 0), new Vector3(2, 2, 2));

        bumperLeft = GameObject.Find("BumperLeft");
        bumperRight = GameObject.Find("BumperRight");
        bumperTop = GameObject.Find("BumperTop");
        bumperBottom = GameObject.Find("BumperBottom");
        CueBall = GameObject.Find("CueBall");
        Ball1 = GameObject.Find("Ball1");
        center = CueBall.GetComponent<Renderer>().bounds.center;
        center2 = Ball1.GetComponent<Renderer>().bounds.center;

        m_Collider1 = CueBall.GetComponent<Collider>();
        m_Collider2 = Ball1.GetComponent<Collider>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        B_Collide();
        if (velocity > 12)
        {
            velocity = 12;
        }
        if (hit == true)
        {
            Ball1.transform.Translate(Vector3.forward * (velocity * Time.deltaTime));
        }
    }

    void B_Collide()
    {
        /*if (m_Collider1.bounds.Intersects(m_Collider2.bounds))
        {
            print("hit!");
            velocity = velocity - (friction * (Time.deltaTime * 10));
            hit = true;
        }*/

        //colliding with rails
        if (this.transform.position.x <= bumperLeft.transform.position.x + bumperSize || this.transform.position.x >= bumperRight.transform.position.x - bumperSize)
        {
            //bounce without reflecting direction
            Quaternion rot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y * inverse, this.transform.rotation.z, this.transform.rotation.w);
            transform.rotation = rot;
        }
        else if (this.transform.position.z >= bumperTop.transform.position.z - bumperSize || this.transform.position.z <= bumperBottom.transform.position.z + bumperSize)
        {
            //reflects direction and bounce
            Quaternion rot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y * inverse, this.transform.rotation.z, this.transform.rotation.w);
            transform.rotation = rot;
            velocity *= inverse;
        }
    }

    void angleChk()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;
        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        if (angle < -5.0f)
        {
            print("turn left");
        }
        else if (angle > 5.0f)
        {
            print("turn right");
        }
        else
        {
            print("forward");
        }
    }
}