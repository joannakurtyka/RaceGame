using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverControll : MonoBehaviour
{
    private const bool V = false;
    private GameObject sucessPanel;
    private GameObject failPanel;
    private GameObject gameOverCanvas;
    private GameObject findedCar;
    
    public float scoreMassForLevel = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        if (gameOverCanvas != null)
        {
            failPanel = gameOverCanvas.transform.GetChild(0).gameObject;
            sucessPanel = gameOverCanvas.transform.GetChild(1).gameObject;
        }
        findedCar = GameObject.Find("car_red_1");
    }

    // Update is called once per frame
    void Update()
    {
        float scoreMass = this.GetComponent<Rigidbody2D>().mass;
        if(findedCar.GetComponent<ObiectMass>().mObiectMass > findedCar.GetComponent<Explosive>().maxMassOnLevel)
        {
            sucessPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (findedCar.GetComponent<PlayerCar>().carIsDestroy == true)
        {
            failPanel.SetActive(true);
            Time.timeScale = 0;
        }
       

    }

}
