using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : Ball
{
    Vector3 hitLocation;
    Vector3 impactDir;
    Vector3 velocity;

    bool cueMovement = false;
    int bumperSize = 1;
    private GameObject bumperLeft;
    private GameObject bumperRight;
    private GameObject bumperTop;
    private GameObject bumperBottom;

    // Start is called before the first frame update
    void Start()
    {
        bumperLeft = GameObject.Find("BumperLeft");
        bumperRight = GameObject.Find("BumperRight");
        bumperTop = GameObject.Find("BumperTop");
        bumperBottom = GameObject.Find("BumperBottom");

    }

    // Update is called once per frame
    public override void Update()
    {
        Movement();
        base.Update();
    }

    void Movement()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Create a ray going into the scene from the screen location
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //the raycast hit info which will be filled by the phsics.Raycast()
            RaycastHit hit;


            //Perform a raycast using our new ray
            if (Physics.Raycast(ray, out hit))
            {
                //if a collision occured. check if its our ball
                if (hit.collider.gameObject.tag == "CueBall" && cueMovement == false)
                {
                    force = 25;
                    acceleration = force / mass;

                    velocity = new Vector3(acceleration * Time.deltaTime, 0, acceleration * Time.deltaTime);
                    impactDir = transform.position - hit.point;
                    impactDir.y = 0;

                    hitLocation = new Vector3(-hit.point.x, 0, -hit.point.z);
                    print(hit.point.y);
                }
            }
        }


        //velocity = velocity + (acceleration * Time.deltaTime) /10;
        transform.Translate(impactDir.x * velocity.x, 0, impactDir.z * velocity.z);
        //this.transform.Rotate(speed, 0, 0);

        
        if (this.transform.position.x <= bumperLeft.transform.position.x + bumperSize || this.transform.position.x >= bumperRight.transform.position.x - bumperSize)
        {
            //bounce without reflecting direction
            Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y * inverse, transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
            impactDir.x = impactDir.x * inverse;
        }
        else if (this.transform.position.z >= bumperTop.transform.position.z - bumperSize || this.transform.position.z <= bumperBottom.transform.position.z + bumperSize)
        {
            //reflects direction and bounce
            Quaternion rot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y * inverse, this.transform.rotation.z, transform.rotation.w);
            transform.rotation = rot;
            impactDir.z = impactDir.z * inverse;
        }
        
    }
}
