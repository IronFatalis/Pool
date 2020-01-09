using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : Ball
{
    int bumperSize = 1;
    private GameObject bumperLeft;
    private GameObject bumperRight;
    private GameObject bumperTop;
    private GameObject bumperBottom;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    

    // Update is called once per frame
    public override void Update()
    {
        Hit();
        base.Update();
    }

    void Hit()
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
                if (hit.collider.gameObject.tag == "CueBall")
                {
                    force = 200;
                    acceleration = force / mass;

                    velocity = new Vector3(acceleration * Time.deltaTime, 0, acceleration * Time.deltaTime);
                    impactDir = transform.position - hit.point;
                    impactDir.y = 0;

                    hitLocation = new Vector3(-hit.point.x, 0, -hit.point.z);
                    velocity.x = impactDir.x * velocity.x;
                    velocity.y = 0;
                    velocity.z = impactDir.z * velocity.z;

                    print(hit.point.y);
                }
            }
        }


        //transform.Translate(impactDir.x * velocity.x, 0, impactDir.z * velocity.z);
        //this.transform.Rotate(speed, 0, 0);

        
       
    }
}
