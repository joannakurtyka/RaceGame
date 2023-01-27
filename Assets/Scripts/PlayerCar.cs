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
        Debug.Log("Lewa " + carTransfortm.GetComponent<Transform>().position.x);

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (shouldMove == 1 && carTransfortm.GetComponent<Transform>().position.x + (hAxis * speedFactor) > -1.1f && carTransfortm.GetComponent<Transform>().position.x + (hAxis * speedFactor) < 1.1f)
        {
            carTransfortm.Translate(hAxis * speedFactor, 0, 0);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bar")
        {
            carTransfortm.Translate(0, 0, 0);
            followingTBar = collision.gameObject;
            shouldMove = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.LogFormat("{0} trigger stay: {1}", this, collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Lewa tag dupa" + collision.gameObject.tag);
        if(collision.gameObject == followingTBar)
        {
            followingTBar = null;
            Debug.Log("Lewa tag" + collision.gameObject.tag);
            shouldMove = 1;
        }

    }
}
