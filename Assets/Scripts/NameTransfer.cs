using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject iputField;
    public GameObject textDisplay;
    public GameObject uiButton;
   
    public void StoreName()
    {
        theName = iputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Hello " + theName + " to the game";
        // Button Start Game
    
        uiButton.SetActive(true);
    }
}
