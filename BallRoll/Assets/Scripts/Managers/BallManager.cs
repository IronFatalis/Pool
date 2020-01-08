using System.Collections;
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
                    float magnitude = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2) + Mathf.Pow(direction.z, 2));

                    if (magnitude < ballSize)
                    {
                        print(magnitude);
                        float radians = Mathf.Atan2(direction.x, direction.z); //get the angle in radians
                        float angle = radians * (180 / Mathf.PI); //convert it to degrees
                        velocity = new Vector3(angle, 0, angle); //balls new velocity is equal to the magnitude of the direction vector on x and z axes
                        print("velo vector xyz: " + " " + velocity.x + " " + velocity.y + " " + velocity.z); //print the velocity vector
                        ballSecond.transform.Translate(velocity.x * magnitude, 0, velocity.z * magnitude); //move ball according to new velocity

                        //CURRENT NOTES- 2020-01-08 4:24 PM
                        //Velo vector is printing out into console, so there is a real number being generated from my math.
                        //i feel like im just missing something small, or maybe my variables are just slightly off?
                        //the math looks and feels right, as im using an angle
                    }
                }
            }
        }
    }

}
