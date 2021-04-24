using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;
    public TopBarrier topBarrier;
    public SideBarrier sideBarrier;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    public static Vector2 screenSize;

    public string rPadColor = "white";
    public string lPadColor = "white";

    CameraMovement cameraMovement;
    GameObject paddleObject1;
    Vector3 paddlePosition1;
    GameObject paddleObject2;
    Vector3 paddlePosition2;

    Paddle paddle1Script;
    Paddle paddle2Script;

    GameObject[] sceneObjects;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();

        // Convert screen's pixel coordinate into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenSize = new Vector2((topRight.x - bottomLeft.x), (topRight.y - bottomLeft.y));

        // Create Ball
        Ball ball1 = Instantiate (ball) as Ball;

        NormalBarriers();
    }

    public void NormalBarriers()
    {
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init(true, false, rPadColor); // Right paddle
        paddle2.Init(false, false, lPadColor); // Left paddle

        TopBarrier topBarrier1 = Instantiate(topBarrier, new Vector3(0, topRight.y), Quaternion.identity) as TopBarrier;
        TopBarrier topBarrier2 = Instantiate(topBarrier, new Vector3(0, bottomLeft.y), Quaternion.identity) as TopBarrier;
        topBarrier1.Init(true); // Top barrier
        topBarrier2.Init(false); // Bottom barrier
        SideBarrier sideBarrier1 = Instantiate(sideBarrier, new Vector2(topRight.x, 0), Quaternion.identity) as SideBarrier;
        SideBarrier sideBarrier2 = Instantiate(sideBarrier, new Vector2(bottomLeft.x, 0), Quaternion.identity) as SideBarrier;
        sideBarrier1.Init(true); // Right barrier
        sideBarrier2.Init(false); // Left barrier
    }

    public void TopBarriers()
    {
        paddleObject1 = GameObject.Find("PaddleRight");
        paddlePosition1 = paddleObject1.transform.position;
        paddlePosition1.y = paddlePosition1.y + screenSize.y;

        paddleObject2 = GameObject.Find("PaddleLeft");
        paddlePosition2 = paddleObject2.transform.position;
        paddlePosition2.y = paddlePosition2.y + screenSize.y;

        TopBarrier sceneBarrier1 = Instantiate(topBarrier, new Vector2(0, (topRight.y + screenSize.y)), Quaternion.identity) as TopBarrier;
        SideBarrier sceneBarrier2 = Instantiate(sideBarrier, new Vector2(topRight.x, screenSize.y), Quaternion.identity) as SideBarrier;
        SideBarrier sceneBarrier3 = Instantiate(sideBarrier, new Vector2(bottomLeft.x, screenSize.y), Quaternion.identity) as SideBarrier;

        Paddle scenePaddle1 = Instantiate(paddle, paddlePosition1, Quaternion.identity) as Paddle;
        scenePaddle1.Init(true, true, rPadColor); // Right paddle
        Paddle scenePaddle2 = Instantiate(paddle, paddlePosition2, Quaternion.identity) as Paddle;
        scenePaddle2.Init(false, true, lPadColor); // Left paddle

        sceneBarrier1.tag = "Scene Clone";
        sceneBarrier2.tag = "Scene Clone";
        sceneBarrier3.tag = "Scene Clone";
        scenePaddle1.tag = "Scene Clone";
        scenePaddle2.tag = "Scene Clone";

        cameraMovement.MoveUp();
    }

    public void BottomBarriers()
    {
        paddleObject1 = GameObject.Find("PaddleRight");
        paddlePosition1 = paddleObject1.transform.position;
        paddlePosition1.y = paddlePosition1.y - screenSize.y;

        paddleObject2 = GameObject.Find("PaddleLeft");
        paddlePosition2 = paddleObject2.transform.position;
        paddlePosition2.y = paddlePosition2.y - screenSize.y;

        TopBarrier sceneBarrier1 = Instantiate(topBarrier, new Vector2(0, (bottomLeft.y - screenSize.y)), Quaternion.identity) as TopBarrier;
        SideBarrier sceneBarrier2 = Instantiate(sideBarrier, new Vector2(topRight.x, 0 - screenSize.y), Quaternion.identity) as SideBarrier;
        SideBarrier sceneBarrier3 = Instantiate(sideBarrier, new Vector2(bottomLeft.x, 0 - screenSize.y), Quaternion.identity) as SideBarrier;

        Paddle scenePaddle1 = Instantiate(paddle, paddlePosition1, Quaternion.identity) as Paddle;
        scenePaddle1.Init(true, true, rPadColor); // Right paddle
        Paddle scenePaddle2 = Instantiate(paddle, paddlePosition2, Quaternion.identity) as Paddle;
        scenePaddle2.Init(false, true, lPadColor); // Left paddle

        sceneBarrier1.tag = "Scene Clone";
        sceneBarrier2.tag = "Scene Clone";
        sceneBarrier3.tag = "Scene Clone";
        scenePaddle1.tag = "Scene Clone";
        scenePaddle2.tag = "Scene Clone";


        cameraMovement.MoveDown();
    }

    public void RightBarriers(string setColor)
    {
        paddleObject1 = GameObject.Find("PaddleRight");
        paddlePosition1 = paddleObject1.transform.position;
        paddlePosition1.x = paddlePosition1.x + screenSize.x;

        paddleObject2 = GameObject.Find("PaddleLeft");
        paddlePosition2 = paddleObject2.transform.position;
        paddlePosition2.x = paddlePosition2.x + screenSize.x;

        paddle1Script = paddleObject1.GetComponent<Paddle>();
        paddle2Script = paddleObject2.GetComponent<Paddle>();

        if (setColor == "white")
        {
            lPadColor = "white";
            rPadColor = "white";

            paddle1Script.ColorChange(rPadColor);
            paddle2Script.ColorChange(lPadColor);
        }
        else if (setColor == "red")
        {
            rPadColor = "red";

            paddle1Script.ColorChange(rPadColor);
        }

        TopBarrier sceneBarrier1 = Instantiate(topBarrier, new Vector2(screenSize.x, topRight.y), Quaternion.identity) as TopBarrier;
        TopBarrier sceneBarrier2 = Instantiate(topBarrier, new Vector2(screenSize.x, bottomLeft.y), Quaternion.identity) as TopBarrier;
        SideBarrier sceneBarrier3 = Instantiate(sideBarrier, new Vector2((topRight.x + screenSize.x), 0), Quaternion.identity) as SideBarrier;

        Paddle scenePaddle1 = Instantiate(paddle, paddlePosition1, Quaternion.identity) as Paddle;
        scenePaddle1.Init(true, true, rPadColor); // Right paddle
        Paddle scenePaddle2 = Instantiate(paddle, paddlePosition2, Quaternion.identity) as Paddle;
        scenePaddle2.Init(false, true, lPadColor); // Left paddle

        sceneBarrier1.tag = "Scene Clone";
        sceneBarrier2.tag = "Scene Clone";
        sceneBarrier3.tag = "Scene Clone";
        scenePaddle1.tag = "Scene Clone";
        scenePaddle2.tag = "Scene Clone";

        cameraMovement.MoveRight();
    }

    public void LeftBarriers(string setColor)
    {
        paddleObject1 = GameObject.Find("PaddleRight");
        paddlePosition1 = paddleObject1.transform.position;
        paddlePosition1.x = paddlePosition1.x - screenSize.x;

        paddleObject2 = GameObject.Find("PaddleLeft");
        paddlePosition2 = paddleObject2.transform.position;
        paddlePosition2.x = paddlePosition2.x - screenSize.x;

        paddle1Script = paddleObject1.GetComponent<Paddle>();
        paddle2Script = paddleObject2.GetComponent<Paddle>();

        if (setColor == "white")
        {
            lPadColor = "white";
            rPadColor = "white";

            paddle1Script.ColorChange(rPadColor);
            paddle2Script.ColorChange(lPadColor);
        }
        else if (setColor == "red")
        {
            lPadColor = "red";

            paddle2Script.ColorChange(lPadColor);
        }

        TopBarrier sceneBarrier1 = Instantiate(topBarrier, new Vector2((0 - screenSize.x), topRight.y), Quaternion.identity) as TopBarrier;
        TopBarrier sceneBarrier2 = Instantiate(topBarrier, new Vector2((0 - screenSize.x), bottomLeft.y), Quaternion.identity) as TopBarrier;
        SideBarrier sceneBarrier3 = Instantiate(sideBarrier, new Vector2((bottomLeft.x - screenSize.x), 0), Quaternion.identity) as SideBarrier;

        Paddle scenePaddle1 = Instantiate(paddle, paddlePosition1, Quaternion.identity) as Paddle;
        scenePaddle1.Init(true, true, rPadColor); // Right paddle
        Paddle scenePaddle2 = Instantiate(paddle, paddlePosition2, Quaternion.identity) as Paddle;
        scenePaddle2.Init(false, true, lPadColor); // Left paddle

        sceneBarrier1.tag = "Scene Clone";
        sceneBarrier2.tag = "Scene Clone";
        sceneBarrier3.tag = "Scene Clone";
        scenePaddle1.tag = "Scene Clone";
        scenePaddle2.tag = "Scene Clone";

        cameraMovement.MoveLeft();
    }

    public void DestroyBarriers()
    {
        sceneObjects = GameObject.FindGameObjectsWithTag("Scene Clone");
        for (int objNum = 4;  objNum >= 0; objNum--)
        {
            Destroy (sceneObjects[objNum]);
        }
    }

    public void GameEnd(string player)
    {
        if (player == "Left Player Wins")
        {
            UnityEngine.Debug.Log("Left Player Wins");
        }
        else
        {
            UnityEngine.Debug.Log("Right Player Wins");
        }
        Time.timeScale = 0;
    }
}
