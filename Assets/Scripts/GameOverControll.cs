using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverControll : MonoBehaviour
{
    private GameObject sucessPanel;
    private GameObject failPanel;
    private GameObject gameOverCanvas;
    public float scoreMassForLevel = 10f;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        if (gameOverCanvas != null)
        {
            failPanel = gameOverCanvas.transform.GetChild(0).gameObject;
            sucessPanel = gameOverCanvas.transform.GetChild(1).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float scoreMass = this.GetComponent<Rigidbody2D>().mass;
        if(scoreMass > scoreMassForLevel)
        {
          failPanel.SetActive(true);
        }
    }
}
