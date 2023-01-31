using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using Random = UnityEngine.Random;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class GroundGenerator : MonoBehaviour
{
    public GameObject[] randomElement;
    public GameObject barElement;


    public float ObstacleDensity = 0.45f;
    private int randomIdx = 0;
    public int power = 0;
    void Start()
    {
        InvokeRepeating("GenerateNewAsfalt",0, ObstacleDensity);
    }

    void GenerateNewAsfalt()
    {
         // co jakiœ czas nie generue przeszkody, ¿eby by³o ciekawiej
        if (this.name == "LeftObjectGenerator" || this.name == "RightObjectGenerator")
        {
            randomIdx = Random.Range(0, randomElement.Length + 1);
        }
        else
        {
            randomIdx = Random.Range(0, randomElement.Length);
        }

        if (randomIdx < randomElement.Length)
        {
            if ( randomElement[randomIdx].tag == "Stopper")
        {
            power++;
            randomElement[randomIdx].GetComponent<ObiectMass>().mObiectMass = power;
            

        }


            Instantiate(randomElement[randomIdx], this.transform.position, Quaternion.identity);

            // dla lewego panelu generuje dodatkowa bariere pomiedzy panelami, zeby pojazd ni zmiatal przeszod z obu jezdni jednoczesnie
            if (this.name == "LeftObjectGenerator")
            {
                Vector3 pos = this.transform.position;
                pos.x = 0;
                Instantiate(barElement, pos, Quaternion.identity);
            }
        }


    }


}
