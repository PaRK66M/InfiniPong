using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;

    string input;
    public bool isRightPaddle;

    Ball ball;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();

        height = transform.localScale.y;
    }

    public void Init(bool RightPaddle, bool Copy)
    {
        isRightPaddle = RightPaddle;
        bool isCopy = Copy;

        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            if (!isCopy)
            {
                // Place paddle on the right of screen
                pos = new Vector2(GameManager.topRight.x, 0);
                pos -= Vector2.right * transform.localScale.x; // Move a bit to the left
            }

            input = "PaddleRight";
        }
        else
        {
            if (!isCopy)
            {
                //Place paddle on the left of screen
                pos = new Vector2(GameManager.bottomLeft.x, 0);
                pos += Vector2.right * transform.localScale.x; // Move a bit to the right
            }

            input = "PaddleLeft";
        }

        if (!isCopy)
        {
            // Update the paddle's position
            transform.position = pos;
        }

        transform.name = input;
    }

    // Update is called once per fram
    void Update()
    {
        bool isScreenPaused = ball.IsScreenPaused();

        if (!isScreenPaused)
        {
            // Moving the paddle

            // GetAxis is a number between -1 to 1 (-1 for down and 1 for up)
            float move = Input.GetAxis(input) * Time.deltaTime * speed;

            // Restrict paddle movement
            if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
            {
                move = 0;
            }
            else if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
            {
                move = 0;
            }

            transform.Translate(move * Vector2.up);
        }
    }
}
