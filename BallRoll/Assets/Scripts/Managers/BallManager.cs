using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<Ball> BallList;
    public Vector3 impact;

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
                    impact = ballSecond.transform.position - ballFirst.transform.position;
                    float ballDistance = Mathf.Sqrt(Mathf.Pow(impact.x, 2) + Mathf.Pow(impact.y, 2) + Mathf.Pow(impact.z, 2));
                    if (ballDistance < 1)
                    {
                        print(ballDistance);

                    }
                    
                }
            }
        }
    }

}
