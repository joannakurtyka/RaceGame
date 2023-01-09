using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    public float timeToDestruction;

    void Start()
    {
        Destroy(this.gameObject, timeToDestruction);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
