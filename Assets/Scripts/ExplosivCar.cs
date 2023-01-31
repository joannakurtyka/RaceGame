using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivCar : MonoBehaviour
{
    public GameObject explosiveElement;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stopper")
        {
            Instantiate(explosiveElement, this.transform.position, Quaternion.identity);
          
        }
    }


}
