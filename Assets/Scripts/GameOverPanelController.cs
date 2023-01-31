using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadLevelAgain()
    {
        GameManager.instance.OpenLevel(GameManager.instance.currentLevel);
    }


    public void LoadNextLevel()
    {
        GameManager.instance.currentLevel++;
        if (GameManager.instance.currentLevel < GameManager.instance.levelNames.Length)
        {
            GameManager.instance.OpenLevel(GameManager.instance.currentLevel);
        } else
        {
            GameManager.instance.currentLevel = 0;
            GameManager.instance.OpenLevel(GameManager.instance.currentLevel);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

}
