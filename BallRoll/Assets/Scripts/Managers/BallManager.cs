using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<Ball> BallList;
    public Vector3 direction1;
    float ballSize = 1;
    public float acceleration = 0; //acceleration
    float magnitude1 = 0;
    public float totalKE;
    public float afterEnergy;

    List<Ball> ballsChanged;

    // Start is called before the first frame update
    void Start()
    {
        ballsChanged = new List<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Ball ballFirst in BallList)
        {
            bool hasBeenHit = false;
            foreach (Ball ballSecond in BallList)
            {
                if (ballFirst.name != ballSecond.name)
                {
                    direction1 = ballSecond.transform.position - ballFirst.transform.position;
                    magnitude1 = Mathf.Sqrt(Mathf.Pow(direction1.x, 2) + Mathf.Pow(direction1.y, 2) + Mathf.Pow(direction1.z, 2));
                    float tempVelocityX = ballSecond.transform.position.x;
                    float tempVelocityZ = ballSecond.transform.position.z;
                    float tempVelocityF = Mathf.Pow(tempVelocityX + tempVelocityZ, 2);
                    float tempVelocityX2 = ballFirst.transform.position.x;
                    float tempVelocityZ2= ballFirst.transform.position.z;
                    float tempVelocityF2 = Mathf.Pow(tempVelocityX2 + tempVelocityZ2, 2);
                    if (magnitude1 < ballSize)
                    {
                        //float tempMass1 = ballSecond.mass - ballFirst.mass + 0.5f; may end up needing these later. elastic collision values
                        //float tempMass2 = ballFirst.mass + ballSecond.mass;
                        //float standMass = ballFirst.mass * 2;
                        //float radians = Mathf.Atan2(direction.x, direction.z); //get the angle in radians
                        //float angle = radians * (180 / Mathf.PI); //convert it to degrees

                        hasBeenHit = true;

                        ballSecond.kineticEnergy = 0.5f * (tempVelocityF) * ballSecond.mass; //kinetic energy is calculated
                        ballFirst.kineticEnergy = 0.5f * (tempVelocityF2) * ballFirst.mass;
                        ballsChanged.Add(ballSecond);
                        totalKE = ballFirst.kineticEnergy + ballSecond.kineticEnergy;
                        afterEnergy = 0.5f * (ballFirst.mass + ballSecond.mass) * totalKE;
                        ballSecond.lostEnergy = totalKE - afterEnergy;
                        //if i can just find where i apply the lost energy then i think im done...
                        ballSecond.newVelocity = new Vector3(direction1.x * magnitude1, 0, direction1.z * magnitude1) - (ballFirst.velocity / ballSecond.lostEnergy);
                        print("lostenergy:" + " " + ballSecond.lostEnergy);
                        
                        //i need the ball to update its stats beyond just on impact :/ if you look at how this whol thing is set up, everything gets applied ON COLLISION
                        //which is fine and dandy if you only have one ball hitting one ball only once, and nothing else.
                        //where our issues lie are in the fact that the balls will have a high chance of hitting another ball after the cue ball impact,
                        //its an issue becuase we need to keep updating things like kinetic energy and velocity every frame with a boolean ( i think ? )
                        //this is where I thought hasBeenHit would have worked but its the same issue as before, its not constantly updating those necessary values
                        //so the balls maintain a memory of how hard to hit the next ball it contacts based on a value that doesnt get updated
                        //i believe the values are the scalars on our velocity vector
                        if (hasBeenHit)
                        {
                            direction1 = ballSecond.transform.position - ballFirst.transform.position;
                            magnitude1 = Mathf.Sqrt(Mathf.Pow(direction1.x, 2) + Mathf.Pow(direction1.y, 2) + Mathf.Pow(direction1.z, 2));
                            tempVelocityX = ballSecond.transform.position.x;
                            tempVelocityZ = ballSecond.transform.position.z;
                            tempVelocityF = Mathf.Pow(tempVelocityX + tempVelocityZ, 2);
                            tempVelocityX2 = ballFirst.transform.position.x;
                            tempVelocityZ2 = ballFirst.transform.position.z;
                            tempVelocityF2 = Mathf.Pow(tempVelocityX2 + tempVelocityZ2, 2);
                            ballSecond.kineticEnergy = 0.5f * (tempVelocityF) * ballSecond.mass; //kinetic energy is calculated
                            ballFirst.kineticEnergy = 0.5f * (tempVelocityF2) * ballFirst.mass;
                            ballsChanged.Add(ballSecond);
                            totalKE = ballFirst.kineticEnergy + ballSecond.kineticEnergy;
                            afterEnergy = 0.5f * (ballFirst.mass + ballSecond.mass) * totalKE;
                            ballSecond.lostEnergy = totalKE - afterEnergy;
                            //if i can just find where i apply the lost energy then i think im done...
                            ballSecond.newVelocity = new Vector3(direction1.x * magnitude1, 0, direction1.z * magnitude1) - (ballFirst.velocity / ballSecond.lostEnergy);
                            print("lostenergy:" + " " + ballSecond.lostEnergy);
                            hasBeenHit = false;
                        }

                    }
                }
            }
        }
        foreach (Ball ball in ballsChanged)
        {
            ball.ApplyNewVelo();
        }
        ballsChanged.Clear();
    }
}
