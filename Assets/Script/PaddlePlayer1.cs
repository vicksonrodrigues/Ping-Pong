using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePlayer1 : MonoBehaviour
{
    public float paddleSpeed;
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * paddleSpeed;
    }
}
