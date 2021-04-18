using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float cameraSpeed;

    float pos;
    bool moveUp = false;
    bool moveDown = false;
    bool moveRight = false;
    bool moveLeft = false;

    Ball pongBall;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void FindBall()
    {
        pongBall = GameObject.Find("Ball").GetComponent<Ball>();
    }

    public void MoveUp()
    {
        moveUp = true;
        pos = 0;
    }

    public void MoveDown()
    {
        moveDown = true;
        pos = 0;
    }

    public void MoveRight()
    {
        moveRight = true;
        pos = 0;
    }

    public void MoveLeft()
    {
        moveLeft = true;
        pos = 0;
    }

    void Update()
    {
        if (moveUp == true)
        {
            pongBall.ChangePosition(true, 0);
            pos += GameManager.screenSize.y / cameraSpeed;
            transform.position = new Vector3(0, pos, -1);
            if (transform.position == new Vector3(0, GameManager.screenSize.y, -1))
            {
                moveUp = false;
                pongBall.ChangePosition(false, 2);
                transform.position = new Vector3(0, 0, -1);

                gameManager.DestroyBarriers();
            }
        }
        else if (moveDown == true)
        {
            pongBall.ChangePosition(true, 0);
            pos -= GameManager.screenSize.y / cameraSpeed;
            transform.position = new Vector3(0, pos, -1);
            if (transform.position == new Vector3(0, 0 - GameManager.screenSize.y, -1))
            {
                moveDown = false;
                pongBall.ChangePosition(false, 1);
                transform.position = new Vector3(0, 0, -1);

                gameManager.DestroyBarriers();
            }
        }
        else if (moveRight == true)
        {
            pongBall.ChangePosition(true, 0);
            pos += GameManager.screenSize.x / cameraSpeed;
            transform.position = new Vector3(pos, 0, -1);
            if (transform.position == new Vector3(GameManager.screenSize.x, 0, -1))
            {
                moveRight = false;
                pongBall.ChangePosition(false, 4);
                transform.position = new Vector3(0, 0, -1);

                gameManager.DestroyBarriers();
            }
        }
        else if (moveLeft == true)
        {
            pongBall.ChangePosition(true, 0);
            pos -= GameManager.screenSize.x / cameraSpeed;
            transform.position = new Vector3(pos, 0, -1);
            if (transform.position == new Vector3(0 - GameManager.screenSize.x, 0, -1))
            {
                moveLeft = false;
                pongBall.ChangePosition(false, 3);
                transform.position = new Vector3(0, 0, -1);

                gameManager.DestroyBarriers();
            }
        }
    }
}
