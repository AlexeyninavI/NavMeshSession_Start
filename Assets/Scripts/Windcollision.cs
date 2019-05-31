﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windcollision : MonoBehaviour
{
    
    public float force;
    public float timeRemaining = 900f;
    public float timeIncrease = 2;
    bool wind = false;
    float hoverForce;
    int napravlen;
    void Start()
    {
        InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
        
    }

    void Update()
    {
        decreaseTimeRemaining();

        if (timeRemaining < 0 && wind == false)
        {
            hoverForce = force;
            timeRemaining = 900f;
            napravlen = Random.Range(1, 4);
            wind = true;
        }
        else if (timeRemaining < 0 && wind == true)
        {
            hoverForce = 0;
            timeRemaining = 900f;
            wind = false;
        }
        
            
       

        //GuiText.text = timeRemaining + " Seconds remaining!";

    }

    void decreaseTimeRemaining()
    {
        timeRemaining--;
    }
    void OnTriggerStay(Collider other)
    {

        switch (napravlen)
        {
            case 1:
                {
                    if (other.attachedRigidbody)
                        other.attachedRigidbody.AddForce(Vector3.forward * hoverForce);
                    break;
                }
            case 2:
                {
                    if (other.attachedRigidbody)
                        other.attachedRigidbody.AddForce(Vector3.back * hoverForce);
                    break;
                }
            case 3:
                {
                    if (other.attachedRigidbody)
                        other.attachedRigidbody.AddForce(Vector3.right * hoverForce);
                    break;
                }
                
            case 4:
                {
                    if (other.attachedRigidbody)
                        other.attachedRigidbody.AddForce(Vector3.left * hoverForce);
                    break;
                }
                
        }

            
        
       
    }

  
}
