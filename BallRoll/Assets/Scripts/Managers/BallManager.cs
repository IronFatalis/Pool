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
                        float radians = Mathf.Atan2(direction.x, direction.z); //get the angle in radians
                        float angle = radians * (180 / Mathf.PI); //convert it to degrees
                        float tempMass1 = ballSecond.mass - ballFirst.mass + 0.5f;
                        float tempMass2 = ballFirst.mass + ballSecond.mass;
                        float standMass = ballFirst.mass * 2;
                        tempVelocity = new Vector3(0, 0, 0);
                        ballSecond.velocity = new Vector3(direction.x * magnitude * tempMass1 / tempMass2, 0, direction.z * magnitude * tempMass1 / tempMass2);


                        //CURRENT NOTES- 2020-01-08 5:00 PM
                        //HOLY HANNA BARBERA IM CLOSE BOIS
                        //the ball now moves out of the way of the cue ball but with no momentum and it does it very strangely
                    }
                }
            }
        }
    }

}
