﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<Ball> BallList;
    public Vector3 direction;
    Vector3 velocity;
    float ballSize = 1;
    public float acceleration = 0; //acceleration
    public float momentum;
    public float mass = 2;
    float magnitude = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach(Ball ballFirst in BallList)
        {
            foreach(Ball ballSecond in BallList)
            {
                if(ballFirst.name != ballSecond.name)
                {
                    direction = ballSecond.transform.position - ballFirst.transform.position;
                    magnitude = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2) + Mathf.Pow(direction.z, 2));

                    
                    if(ballFirst.name == "CueBall" && magnitude < ballSize)
                    {
                        
                    }


                    if (magnitude < ballSize)
                    {
                        //print(magnitude);
                        float radians = Mathf.Atan2(direction.x, direction.z); //get the angle in radians
                        float angle = radians * (180 / Mathf.PI); //convert it to degrees
                        ballSecond.velocity = new Vector3(direction.x * magnitude, 0, direction.z * magnitude);
                         

                        //CURRENT NOTES- 2020-01-08 5:00 PM
                        //HOLY HANNA BARBERA IM CLOSE BOIS
                        //the ball now moves out of the way of the cue ball but with no momentum and it does it very strangely
                    }
                }
            }
        }
    }

}
