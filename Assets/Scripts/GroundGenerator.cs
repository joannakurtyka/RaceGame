using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using Random = UnityEngine.Random;



public class GroundGenerator : MonoBehaviour
{
    public GameObject randoElement;
    public float ObstacleDensity = 0.45f;

    void Start()
    {
        InvokeRepeating("GenerateNewAsfalt",0, ObstacleDensity);
    }

    void GenerateNewAsfalt()
    {
        Instantiate(randoElement, this.transform.position,Quaternion.identity);
    }


}
