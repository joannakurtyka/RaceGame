using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Explosive : MonoBehaviour
{
    private GameObject failPanel;
    public int maxMassOnLevel = 100;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
 

        if (this.gameObject.tag == "Car" && collision.gameObject.tag == "Stopper")
        {
         //   Debug.Log(this.gameObject.tag + " "+ this.GetComponent<ObiectMass>().mObiectMass + "\n " 
          //      + collision.gameObject.tag + " "+ collision.GetComponent<ObiectMass>().mObiectMass);
            if (collision.GetComponent<ObiectMass>().mObiectMass <= this.GetComponent<ObiectMass>().mObiectMass)
            {
               this.GetComponent<ObiectMass>().mObiectMass += collision.GetComponent<ObiectMass>().mObiectMass;
             //   this.GetComponent<PlayerCar>().floatingPointsText.GetComponent<TextMesh>().text = this.GetComponent<ObiectMass>().mObiectMass.ToString();
                Destroy(collision.gameObject, 0);

                }
                else
                {
                Debug.Log("*************** " );
                Debug.Log("Car mass " + this.GetComponent<ObiectMass>().mObiectMass);
                Debug.Log("Cone mass " + collision.GetComponent<ObiectMass>().mObiectMass);
                Debug.Log("Max on level "+maxMassOnLevel);
                this.GetComponent<PlayerCar>().carIsDestroy = true;
                
            }
        }
    }
}
