using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using Random = UnityEngine.Random;
using System.Security.Cryptography.X509Certificates;





public class GroundGenerator : MonoBehaviour
{
    public GameObject[] randomElement;
    public float ObstacleDensity = 0.45f;
    private int randomIdx = 0;
    public int power = 0;

    void Start()
    {
        InvokeRepeating("GenerateNewAsfalt",0, ObstacleDensity);
    }

    void GenerateNewAsfalt()
    {
        randomIdx = Random.Range(0, randomElement.Length);

        if (randomElement[randomIdx].tag == "Stopper")
        {
            power++;
            randomElement[randomIdx].GetComponent<Rigidbody2D>().mass = power;

        }
            
            Instantiate(randomElement[randomIdx], this.transform.position,Quaternion.identity);
        
    }


}
