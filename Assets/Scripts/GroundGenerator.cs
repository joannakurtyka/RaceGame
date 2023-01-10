using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using Random = UnityEngine.Random;



public class GroundGenerator : MonoBehaviour
{
    public GameObject[] randomElement;
    public float ObstacleDensity = 0.45f;

    void Start()
    {
        InvokeRepeating("GenerateNewAsfalt",0, ObstacleDensity);
    }

    void GenerateNewAsfalt()
    {
        Instantiate(randomElement[Random.Range(0,randomElement.Length)], this.transform.position,Quaternion.identity);
    }


}
