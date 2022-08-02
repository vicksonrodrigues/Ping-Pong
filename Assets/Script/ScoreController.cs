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
        int gamepoint =GameManager.instance.gamePoint;
 
        if (this.player1score >= gamepoint || this.player2score >= gamepoint)
        {
            if(this.player1score>=gamepoint)
            {
                GameManager.instance.winner = "Player 1";
            }
            if (this.player2score>=gamepoint)
            {
                GameManager.instance.winner = "Player 2";
            }
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
