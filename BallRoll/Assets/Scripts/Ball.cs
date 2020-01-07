using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float b_fric = 2; //friction
    public float b_ma = 2; //mass
    private float b_accel = 0; //acceleration
    public float b_for = 1; //force
    public float b_velo = 0; //velocity
    public float b_dist = 0; //unused
    public float b_momen = 0; //momentum
    public float inverse = -1;
    int bumperSize = 1;
    int ballSize = 1;
    public float b_radius = 0.5f;
    Bounds b;
    bool hit = false;

    private GameObject bumperLeft;
    private GameObject bumperRight;
    private GameObject bumperTop;
    private GameObject bumperBottom;
    private GameObject CueBall, Ball1;
    Collider m_Collider1, m_Collider2;
    private Vector3 center;
    private Vector3 center2;

    // Start is called before the first frame update
    void Start()
    {
        b_accel = b_ma * b_for;
        b_velo = b_accel / Time.deltaTime;
        b_momen = b_ma * b_velo;

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
    void Update()
    {
        B_Collide();
        if (b_velo > 12)
        {
            b_velo = 12;
        }
        if (hit == true)
        {
            Ball1.transform.Translate(Vector3.forward * (b_velo * Time.deltaTime));
        }
    }

    void B_Collide()
    {
        if (m_Collider1.bounds.Intersects(m_Collider2.bounds))
        {
            Debug.Log("hit!");
            Debug.Log("extents: " + m_Collider1.bounds.extents);
            b_velo = b_velo - (b_fric * (Time.deltaTime * 10));
            hit = true;
        }
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
            b_velo *= inverse;
        }
    }
}