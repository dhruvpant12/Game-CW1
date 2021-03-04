using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEgg : MonoBehaviour
{
    Vector3 lowerend = new Vector3();    
    Vector3 upperend = new Vector3();
    Vector3 comparepostion = new Vector3();
    int speed = 3;
    bool goingup;
    int i ;


    // Start is called before the first frame update
    void Start()
    {
        goingup = true;
        lowerend = transform.position;
        upperend = new Vector3(transform.position.x, 5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        comparepostion = transform.position;
         
    }

    void FixedUpdate()
    {
        

        if  ( goingup)
        {
           
            transform.Translate(0f, speed * Time.deltaTime, 0f);
            if(comparepostion==upperend)
            {
                goingup = false;
            }
            
            
        }

        

        if (!goingup)
       {
            
          transform.Translate(0f, -speed * Time.deltaTime, 0f);
            if(comparepostion==lowerend)
            {
                goingup = true;
            }
             
       }

    }
}