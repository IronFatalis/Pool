using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetMouseButtonDown(0))
        {
            //Create a ray going into the scene from the screen location
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //the raycast hit info which will be filled by the phsics.Raycast()
            RaycastHit hit;
            

            //Perform a raycast using our new ray
            if(Physics.Raycast(ray, out hit))
            {
                //if a collision occured. check if its our ball
                if(hit.collider.gameObject.tag == "CueBall")
                {
                    print(hit.point);
                }
            }


        }
    }
}
