using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedIncrease;

    float radius;
    Vector2 direction;
    public bool screenPause = false;
    bool isVerticalShift = false;
    bool isHorizontalShift = false;

    GameManager gameManager;
    CameraMovement cameraMove;
    ScoreMovement scoreMovement;

    Vector2 topRight;
    Vector2 bottomLeft;

    int stagePosition = 3;

    // Start is called before the first frame update
    void Start()
    {
        transform.name = "Ball";

        float startDirectionX = Random.Range(-1, 1);
        if (startDirectionX == 0)
        {
            startDirectionX = 1;
        }
        
        float startDirectionY = Random.Range(-1, 1);
        if (startDirectionY == 0)
        {
            startDirectionY = 1;
        }

        direction = new Vector2(startDirectionX, startDirectionY);
        radius = transform.localScale.x / 2; // half of the width

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cameraMove = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
        scoreMovement = GameObject.FindGameObjectWithTag("UIScore").GetComponent<ScoreMovement>();

        cameraMove.FindBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (screenPause == false)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle" && screenPause == false)
        {
            bool isRightPaddle = other.GetComponent<Paddle>().isRightPaddle;

            // If hitting right paddle and moving right, flip direction
            if (isRightPaddle == true && direction.x > 0)
            {
                direction.x = -direction.x;
                speed = speed + speedIncrease;
            }
            // If hitting left paddle and moving left, flip direction
            else if (isRightPaddle == false && direction.x < 0)
            {
                direction.x = -direction.x;
                speed = speed + speedIncrease;
            }
        }
        else if (other.tag == "Vertical Barrier")
        {
            
            bool isTopBarrier = other.GetComponent<TopBarrier>().isTopBarrier;

            if (isTopBarrier == true && isVerticalShift == false)
            {
                isVerticalShift = true;
                gameManager.TopBarriers();
            }

            else if (isTopBarrier == false && isVerticalShift == false)
            {
                isVerticalShift = true;
                gameManager.BottomBarriers();
            }
        }
        else if (other.tag == "Side Barrier")
        {
            bool isRightBarrier = other.GetComponent<SideBarrier>().isRightBarrier;

            if (isRightBarrier == true && isHorizontalShift == false)
            {
                isHorizontalShift = true;
                stagePosition++;
                if (stagePosition == 6)
                {
                    gameManager.GameEnd("left");
                }
                else if (stagePosition == 5)
                {
                    gameManager.RightBarriers("red");
                    scoreMovement.MoveRight("red");
                }
                else
                {
                    gameManager.RightBarriers("white");
                    scoreMovement.MoveRight("white");
                }
            }

            else if (isRightBarrier == false && isHorizontalShift == false)
            {
                UnityEngine.Debug.Log("Left shift");
                isHorizontalShift = true;
                stagePosition--;
                if (stagePosition == 0)
                {
                    gameManager.GameEnd("right");
                }
                else if (stagePosition == 1)
                {
                    gameManager.LeftBarriers("red");
                    scoreMovement.MoveLeft("red");
                }
                else
                {
                    gameManager.LeftBarriers("white");
                    scoreMovement.MoveLeft("white");
                }
            }
        }
        else if (other.tag == "Vertical Collider")
        {
            isVerticalShift = false;
        }
        else if (other.tag == "Horizontal Collider")
        {
            isHorizontalShift = false;
        }
    }

    public void ChangePosition(bool condition, int location)
    {
        screenPause = condition;
        if (screenPause == false)
        {
            if (location == 1) // Top
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + GameManager.screenSize.y);
            }
            else if(location == 2) // Bottom
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - GameManager.screenSize.y);
            }
            else if (location == 3) // Right
            {
                transform.position = new Vector2(transform.position.x + GameManager.screenSize.x, transform.position.y);
            }
            else if (location == 4) // Left
            {
                transform.position = new Vector2(transform.position.x - GameManager.screenSize.x, transform.position.y);
            }
        }
    }

    public bool IsScreenPaused()
    {
        return screenPause;
    }

    public void DirectionUpdate(float xDir, float yDir) 
    {
        if (xDir != 0)
        {
            direction.x = xDir;
        }
        if (yDir != 0)
        {
            direction.y = yDir;
        }
    }
}
