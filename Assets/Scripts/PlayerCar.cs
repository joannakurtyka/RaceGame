using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    int shouldMove   = 1;
    Transform carTransfortm;
    public float speedFactor = 0.1f;
    GameObject followingTBar;

    // Start is called before the first frame update
    void Start()
    {
        carTransfortm = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (shouldMove == 1 && carTransfortm.GetComponent<Transform>().position.x + (hAxis * speedFactor) > -1.1f && carTransfortm.GetComponent<Transform>().position.x + (hAxis * speedFactor) < 1.1f)
        {
            carTransfortm.Translate(shouldMove * hAxis * speedFactor, 0, 0);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bar")
        {
            if (carTransfortm.GetComponent<Transform>().position.x < 0)
            {
                carTransfortm.Translate(-0.5f, 0, 0);
            } else { carTransfortm.Translate(0.5f, 0, 0);  }
            followingTBar = collision.gameObject;
            shouldMove = 1;
        }
    }
    
   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == followingTBar)
        {
            followingTBar = null;
            shouldMove = 1;
        }

    }
}
