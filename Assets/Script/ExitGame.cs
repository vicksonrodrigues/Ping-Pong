using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{

    public GameObject gameOverText;
    public GameObject winnerText;
    public GameObject winnerNameText;

    private void Update()
    {
        if (GameManager.instance.playerVsPlayer)
        {
            winnerText.SetActive(true);
        }
        else
        {
            if(GameManager.instance.winner == "Player 2")
            {
                winnerText.SetActive(false);
                gameOverText.SetActive(true);

            }
            else
            {
                winnerText.SetActive(true);
                gameOverText.SetActive(false);
            }
        }

        winnerNameText.GetComponent<Text>().text = GameManager.instance.winner + " is the Winner";
    }


    public void PlayAgain(int sceneID)
    {
        GameManager.instance.MoveToScene(sceneID);
        Destroy(GameManager.instance);
        
    }
    public void Exit()
    {
        Debug.Log("Game Quitting");
        Destroy(GameManager.instance);
        Application.Quit();


    }
}
