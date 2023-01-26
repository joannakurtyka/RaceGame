using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    Transform carTransfortm;
    public float speedFactor = 0.1f;

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
        if (carTransfortm.GetComponent<Transform>().position.x + (hAxis * speedFactor) > -1.1f && carTransfortm.GetComponent<Transform>().position.x + (hAxis * speedFactor) < 1.1f)
        {
            carTransfortm.Translate(hAxis * speedFactor, 0, 0);
        }
   
    }
}
