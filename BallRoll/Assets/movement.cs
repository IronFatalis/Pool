using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float gravity = 1;
    public float speed = 0;
    public float force = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            speed = speed + force;
        }
        else if (!Input.GetMouseButton(0) && speed > 0)
        {
            speed = speed - force;
        }

        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
