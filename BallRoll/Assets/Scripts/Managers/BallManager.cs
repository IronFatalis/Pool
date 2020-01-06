using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float speed = 0;
    public float force = 1;
    public float friction = 2;
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
            speed = speed + force;
        }
        else if (!Input.GetMouseButton(0))
        {
            if (speed >= 0.5)
            {
                speed = speed - (friction * (Time.deltaTime * 10));
            }
            else if (speed <= -0.5)
            {
                speed = speed + (friction * (Time.deltaTime * 10));
            }
            else
            {
                speed = 0;
            }
        }
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        //this.transform.Rotate(speed, 0, 0);
        print(speed);
    }
}
