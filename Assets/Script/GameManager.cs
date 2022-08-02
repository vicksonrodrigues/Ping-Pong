using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int gamePoint = 5;
    public bool playerVsPlayer = false;
    public string winner;


    private void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void SetGameMode()
    {
        if (!playerVsPlayer)
        {
            playerVsPlayer = true;
        }
        else
            playerVsPlayer = false;


    }

    public void SetGamePoint()
    {
        Dropdown dd = GameObject.FindGameObjectWithTag("GamePointDropdown").GetComponent<Dropdown>();
        gamePoint = int.Parse(dd.options[dd.value].text);
    }


    public void MoveToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);

    }

    
}
