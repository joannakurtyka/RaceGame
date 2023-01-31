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
            AudioManager.instance.Play("Explosion");

            if (collision.GetComponent<ObiectMass>().mObiectMass <= this.GetComponent<ObiectMass>().mObiectMass)
            {
               this.GetComponent<ObiectMass>().mObiectMass += (collision.GetComponent<ObiectMass>().mObiectMass>0)? collision.GetComponent<ObiectMass>().mObiectMass:1;
                Destroy(collision.gameObject, 0);
                AudioManager.instance.Play("LittleExplosion");
            }
                else
                {
                AudioManager.instance.Play("Explosion");
                this.GetComponent<PlayerCar>().carIsDestroy = true;
                
            }
        }
    }
}
