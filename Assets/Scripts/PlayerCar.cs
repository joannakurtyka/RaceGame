using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlayerCar : MonoBehaviour
{
    int shouldMove   = 1;
    Transform carTransfortm;
    public float speedFactor = 0.1f;
    GameObject followingTBar;
    public bool carIsDestroy = false;
    public GameObject floatingPointsText;
    public GameObject cFloatingPointsText;
    private float pHAxis = 0;

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
        if(pHAxis == 0 && hAxis != 0)
        {
            AudioManager.instance.Play("Speeding");
        }
        pHAxis = hAxis;

        if (floatingPointsText)
        {
            if (this.GetComponent<ObiectMass>().mObiectMass.ToString() != floatingPointsText.GetComponent<TextMesh>().text)
            {

                Vector3 floatP = carTransfortm.GetComponent<Transform>().position;
                floatP.y = floatP.y - 1.15f;
                floatP.x = 0;
                floatingPointsText.layer = 5;
                floatingPointsText.GetComponent<TextMesh>().text = this.GetComponent<ObiectMass>().mObiectMass.ToString();
                floatingPointsText.GetComponent<TextMesh>().fontSize = 16;
                floatingPointsText.GetComponent<AutoMoveAndRotate>().moveUnitsPerSecond.value.y = 0;
                floatingPointsText.GetComponent<TextMesh>().text = this.GetComponent<ObiectMass>().mObiectMass.ToString();
                if(cFloatingPointsText!=null)
                {
                    DestroyImmediate(cFloatingPointsText, true);
                }
                cFloatingPointsText = Instantiate(floatingPointsText, floatP, Quaternion.identity);


            }
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
