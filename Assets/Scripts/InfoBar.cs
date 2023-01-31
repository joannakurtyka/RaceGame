using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class InfoBar : MonoBehaviour
{
    
    public string lvl;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMesh>().text = lvl;
    }

    // Update is called once per frame
    void Update()
    {
                       
        
    }
}
