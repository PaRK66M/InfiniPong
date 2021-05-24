using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float cameraSpeed;
    int cameraSpeedCounter = 0;

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
        if (cameraSpeedCounter == cameraSpeed)
        {
            cameraSpeedCounter = 0;
        }

        if (moveUp == true)
        {
            pongBall.ChangePosition(true, 0);
            pos += GameManager.screenSize.y / cameraSpeed;
            transform.position = new Vector3(0, pos, -1);
            cameraSpeedCounter++;
            if (cameraSpeedCounter == cameraSpeed)
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
            cameraSpeedCounter++;
            if (cameraSpeedCounter == cameraSpeed)
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
            cameraSpeedCounter++;
            if (cameraSpeedCounter == cameraSpeed)
            {
                moveRight = false;
                pongBall.ChangePosition(false, 4);
                pongBall.DirectionUpdate(1);
                transform.position = new Vector3(0, 0, -1);

                gameManager.DestroyBarriers();
            }
        }
        else if (moveLeft == true)
        {
            pongBall.ChangePosition(true, 0);
            pos -= GameManager.screenSize.x / cameraSpeed;
            transform.position = new Vector3(pos, 0, -1);
            cameraSpeedCounter++;
            if (cameraSpeedCounter == cameraSpeed)
            {
                moveLeft = false;
                pongBall.ChangePosition(false, 3);
                pongBall.DirectionUpdate(-1);
                transform.position = new Vector3(0, 0, -1);

                gameManager.DestroyBarriers();
            }
        }
    }
}
