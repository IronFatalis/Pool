using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<Ball> BallList;
    public Vector3 direction;
    Vector3 tempVelocity;
    float ballSize = 1;
    public float acceleration = 0; //acceleration
    float magnitude = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool hasCollided = false;
        foreach(Ball ballFirst in BallList)
        {
            foreach(Ball ballSecond in BallList)
            {
                if(ballFirst.name != ballSecond.name)
                {
                    direction = ballSecond.transform.position - ballFirst.transform.position;
                    magnitude = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2) + Mathf.Pow(direction.z, 2));

                    if (magnitude < ballSize)
                    {
                        //print(magnitude);
                        hasCollided = true;
                        float radians = Mathf.Atan2(direction.x, direction.z); //get the angle in radians
                        float angle = radians * (180 / Mathf.PI); //convert it to degrees
                        float tempMass1 = ballSecond.mass - ballFirst.mass;
                        float tempMass2 = ballFirst.mass + ballSecond.mass;
                        float standMass = ballSecond.mass * 2;
                        ballSecond.velocity = new Vector3(direction.x * magnitude, 0, direction.z * magnitude);
                        ballFirst.velocity = new Vector3((direction.x) * -1 * magnitude, 0, (direction.z) * -1 * magnitude);
                        if (hasCollided)
                        {
                            ballSecond.velocity = ballSecond.velocity - new Vector3(0, 0, 0) * .005f;
                            ballFirst.velocity = ballFirst.velocity - new Vector3(0, 0, 0) * .005f;
                            hasCollided = false;
                        }
                        //CURRENT NOTES- 2020-01-09 6:09 PM
                        //so ive noticed that collsion works perfectly as long as its only 1 ball hitting one ball...
                        //which means that the velocity gets bigger and bigger if more than one collsion happens before the ball stops moving
                        //ie the hit ball has its velocity from original collision plus the added velocity of any other collsions that happen
                        //while its in motion
                        //i have to find a way to apply more negative to a ball whenever it gets hit more than once
                    }
                }
            }
        }
    }

}
