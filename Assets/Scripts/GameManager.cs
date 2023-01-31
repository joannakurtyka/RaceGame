using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ten obiekt jest jedn¹ sztuk¹ dla wszyskich scen, jednym egzemplarzem, wiêc implementujemy tutaj singleton
    public static GameManager instance = null;

    public int currentLevel;

    public string[] levelNames;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenLevel(int newLevelNum)
    {
        SceneManager.LoadScene(levelNames[newLevelNum]);
    }

}
