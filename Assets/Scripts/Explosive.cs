using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
/*
        UnityEngine.Debug.Log("====== ");
        UnityEngine.Debug.Log("Name " + this.name);
        UnityEngine.Debug.Log("Masa " + this.GetComponent<Rigidbody2D>().mass);
        UnityEngine.Debug.Log("Name colision" + collision.name);
        UnityEngine.Debug.Log("Masa " + collision.GetComponent<Rigidbody2D>().mass);
        UnityEngine.Debug.Log("====== ");
*/

        if (collision.GetComponent<Rigidbody2D>().mass > this.GetComponent<Rigidbody2D>().mass)
        {
            UnityEngine.Debug.Log("====== ");
            UnityEngine.Debug.Log("Name " + this.name);
            UnityEngine.Debug.Log("Masa " + this.GetComponent<Rigidbody2D>().mass);
            UnityEngine.Debug.Log("Name colision" + collision.name);
            UnityEngine.Debug.Log("Masa " + collision.GetComponent<Rigidbody2D>().mass);

            collision.GetComponent<Rigidbody2D>().mass++;
            UnityEngine.Debug.Log("Masa " + collision.GetComponent<Rigidbody2D>().mass);
            UnityEngine.Debug.Log("tag :"+ this.name);
            UnityEngine.Debug.Log("====== ");
            Destroy(this.gameObject, 0);
            
        }
    }
}
