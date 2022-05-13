using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public ScoreController scoreController;
    public float ballSpeed;
    public float maxBallSpeed;
    public float speedIncrement;

    int hitCounter = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
        
    }

    public IEnumerator StartBall(bool isStartingPlayer1=true)
    {
        this.PositionBall(isStartingPlayer1);
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);

        if (isStartingPlayer1)
        {
            this.Movement(new Vector2(-1, 0));
        }
        else
        {
            this.Movement(new Vector2(1, 0));
        }
    }

    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public void Movement(Vector2 dir)

    {
        dir = dir.normalized;
        float speed = this.ballSpeed + this.hitCounter * this.speedIncrement;
        Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = dir * speed;
    }

    public void IncreaseHitCounter()
    {
        if(this.hitCounter*this.speedIncrement <= this.maxBallSpeed)
        {
            this.hitCounter++;
        }
    }

    void BounceFromPaddle(Collision2D c )
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 paddlePosition = c.gameObject.transform.position;

        float paddleHeight = c.collider.bounds.size.y;
        float x;
        if (c.gameObject.name == "LeftPaddle")
        {

            x = 1;
        }
        else
        {
            x = -1;
        }

        float y = (ballPosition.y - paddlePosition.y) / paddleHeight;
        this.IncreaseHitCounter();
        this.Movement(new Vector2(x,y));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "RightPaddle" || collision.gameObject.name == "LeftPaddle")
        {
            this.BounceFromPaddle(collision);
        }
        else if(collision.gameObject.name == "LeftWall")
        {
            Debug.Log("Collision with left wall");
            scoreController.GoalPlayer2();
            StartCoroutine(this.StartBall(true));
        }
        else if(collision.gameObject.name == "RightWall")
        {
            Debug.Log("Collision with right wall");
            scoreController.GoalPlayer1();
            StartCoroutine(this.StartBall(false));
        }
    }


}
