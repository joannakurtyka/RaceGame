using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    InputField iField;
    void Start()
    {
        iField = this.GetComponent<InputField>();
        iField.text = "sdf";    
    }

    // Update is called once per frame
    void Update()
    {
        iField.text = "Score\n" +
            "1. Asia    480\n" +
            "2. Tomek   432\n" +
            "3. Karina  220\n";
    }
}
