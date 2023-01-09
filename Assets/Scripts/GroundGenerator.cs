using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using Random = UnityEngine.Random;



public class GroundGenerator : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI score;
    public int scoreValue = 100;
    public GameObject[] groundPrefabs;
    public float maxStep;
    public float maxHeight = -3f;
    public float minHeight = 0.5f;
    private float previousGroundY = -1.34f;
    public float spaceBetweenPlatforms = 1;
    private int randomIdx;
    private float sizeXsmall = 1.28f;
    private float sizeX;
    private float xPosition;
   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateNewGrond", 0, 2.5f);
        UnityEngine.Debug.Log("GENERUJE!");
         StartCoroutine(CreateObstacle(0.8f));
        UnityEngine.Debug.Log("co jest?");
    }

   
       IEnumerator CreateObstacle(float time)
       {
           yield return new WaitForSeconds(0);


             while (true)
           {
               randomIdx = Random.Range(0, groundPrefabs.Length);
               sizeX = groundPrefabs[randomIdx].GetComponent<BoxCollider2D>().size.x;
            UnityEngine.Debug.Log("SizeX " + sizeX + " sizeXSmall " + sizeXsmall);
            UnityEngine.Debug.Log("Przed wait");

               float newY;
               do
               {
                   newY = Random.Range(minHeight, maxHeight);
               } while (newY > maxStep + previousGroundY);

               if (sizeX > sizeXsmall)
               {
                   xPosition = this.transform.position.x;
               }
               else
               {
                   xPosition = this.transform.position.x - sizeXsmall;
               }

               Vector3 targetPrefabPosition = new Vector3(xPosition, newY, this.transform.position.z);

               previousGroundY = targetPrefabPosition.y;

               if (scoreValue > 3)
               {
                   Instantiate(groundPrefabs[randomIdx], targetPrefabPosition, Quaternion.identity);
               }
               if (scoreValue > 0) { scoreValue--; }
               score.text = scoreValue.ToString();

               if (sizeX > sizeXsmall)
               {
                UnityEngine.Debug.Log("Time  " + time * 3);
                   yield return new WaitForSeconds(time * 3);
               }
               else
               {
                UnityEngine.Debug.Log("Time -short  " + time);
                   yield return new WaitForSeconds(time);
               }
            UnityEngine.Debug.Log("jest");
           }

       }
     
    void GenerateNewGrond()
    {
         
        Vector3 targetPrefabPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z); 
               
    }


}
