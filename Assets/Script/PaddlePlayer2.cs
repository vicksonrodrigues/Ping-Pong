using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePlayer2 : MonoBehaviour
{
    public GameObject ball;
    public float paddleSpeed;

    private void FixedUpdate()
    {
        
        if (GameManager.instance.playerVsPlayer)
        {
            PlayerMovement();
        }
        else
        {
            PlayerAI();
        }
    }

    private void PlayerMovement()
    {
        float v = Input.GetAxisRaw("Vertical2");

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * paddleSpeed;
    }

    private void PlayerAI()
    {
        if(Mathf.Abs(this.transform.position.y - ball.transform.position.y)>50)
        {
            if(transform.position.y < ball.transform.position.y) 
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * paddleSpeed;

            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * paddleSpeed;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
