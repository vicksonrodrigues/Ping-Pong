using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gamePoint = 5;
    public bool playerVsPlayer = false;


    public void SetGameMode()
    {
        if (!playerVsPlayer)
        {
            playerVsPlayer = true;
        }
        else
            playerVsPlayer = false;
        PlayerPrefs.SetInt("playervsplayer", playerVsPlayer ? 1 : 0);

    }

    private void Awake()
    {
        PlayerPrefs.SetInt("playervsplayer", playerVsPlayer ? 1 : 0);
        PlayerPrefs.SetInt("gamepoint", gamePoint);
    }

    public void SetGamePoint()
    {
        Dropdown dd = GameObject.FindGameObjectWithTag("GamePointDropdown").GetComponent<Dropdown>();
        gamePoint = int.Parse(dd.options[dd.value].text);
        PlayerPrefs.SetInt("gamepoint", gamePoint);
    }

    
    public void MoveToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);

    }

    public void ExitGame()
    {
        Debug.Log("Game Quitting");
        ClearPlayerPref();
        Application.Quit();

    }

    public void ClearPlayerPref()
    {
        PlayerPrefs.DeleteAll();
    }
}
