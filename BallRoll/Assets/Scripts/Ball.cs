using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float friction = 1.05f; //friction
    public float mass = 2; //mass
    public float acceleration = 0; //acceleration
    public float force = 0; //force
    public float distance = 0; //unused
    public float momentum = 0; //momentum
    public float inverse = -1;
    int bumperSize = 1;
    public float b_radius = 0.5f;
    Bounds b;
    public Transform target;
    public Vector3 hitLocation;
    public Vector3 impactDir;
    public Vector3 velocity;
    public Vector3 newVelocity;
    public float kineticEnergy;
    public float lostEnergy;
    public float totalEnergy;



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
    public virtual void Start()
    {
        

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
        if (gameObject.name == "CueBall")
            print(velocity);
        Movement();

        if (this.transform.position.x <= bumperLeft.transform.position.x + bumperSize || this.transform.position.x >= bumperRight.transform.position.x - bumperSize)
        {
            //bounce without reflecting direction
            Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y * inverse, transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
            velocity.x *= inverse;
            //impactDir.x = impactDir.x * inverse;
        }
        else if (this.transform.position.z >= bumperTop.transform.position.z - bumperSize || this.transform.position.z <= bumperBottom.transform.position.z + bumperSize)
        {
            //reflects direction and bounce
            Quaternion rot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y * inverse, this.transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
            velocity.z *= inverse;
            //impactDir.z = impactDir.z * inverse;
        }

        if (gameObject.name == "CueBall")
            print(velocity);
    }

    void Movement()
    {

        transform.Translate(velocity);
        velocity.x = velocity.x / friction;
        velocity.z = velocity.z / friction;

    }

    public void ApplyNewVelo()
    {
        velocity = newVelocity;
    }
}