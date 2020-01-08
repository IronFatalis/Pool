using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<Ball> BallList;
    public Vector3 direction;

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
                    float ballDistance = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2) + Mathf.Pow(direction.z, 2));
                    if (ballDistance < 1)
                    {
                        print(ballDistance);
                        float radians = Mathf.Atan2(direction.x, direction.z);
                        float angle = radians * (180 / Mathf.PI);
                    }
                    
                }
            }
        }
    }

}
