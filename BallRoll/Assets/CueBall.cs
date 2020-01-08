using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : Ball
{

    bool cueMovement = false;

    // Update is called once per frame
    public override void Update()
    {
        if (velocity != 0)
        {
            cueMovement = true;
        }
        else
        {
            cueMovement = false;
        }
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
                    acceleration = mass * force;
                    velocity = acceleration / Time.deltaTime;
                    momentum = mass * velocity;
                    print(hit.point);
                }
            }
        }
        if (cueMovement == true)
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
    }

}
