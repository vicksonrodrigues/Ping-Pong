using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public int player1score = 0;
    public int player2score = 0;

    public GameObject Player1Score;
    public GameObject Player2Score;

    private void Update()
    {
        int gamepoint =PlayerPrefs.GetInt("gamepoint");
        /*Debug.Log("P1:"+player1score);
        Debug.Log("P2:"+player2score);
        Debug.Log("GP"+gamepoint);*/
        if (this.player1score >= gamepoint || this.player2score >= gamepoint)
        {
            Debug.Log("Game Won");
            DefaultScore();
            SceneManager.LoadScene(2);
        }
    }

    private void FixedUpdate()
    {
            Text uiPlayer1Score = Player1Score.GetComponent<Text>();
            uiPlayer1Score.text = this.player1score.ToString();

            Text uiPlayer2Score = this.Player2Score.GetComponent<Text>();
            uiPlayer2Score.text = this.player2score.ToString();
        
    }

    public void GoalPlayer1()
    {
        player1score++;
    }

    public void GoalPlayer2()
    {
        player2score++;
    }

    public void DefaultScore()
    {
        player1score = 0;
        player2score = 0;
    }
}
