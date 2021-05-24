using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas CanvasUIElement;//Set in editor
    public GameObject canvas;
    public GameObject playAgainButton;
    public GameObject returnToMenuButton;
    public GameObject leftWinnerDisplay;
    public GameObject rightWinnerDisplay;
    private float CanvasWidth;
    private float CanvasHeight;
    string theWinner;

    GameObject canvasParent;
    ScoreMovement scoreMovement;

    GameObject button;
    GameObject winnerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        canvasParent = GameObject.Find("Canvas");
        scoreMovement = canvasParent.transform.GetChild(0).gameObject.GetComponent<ScoreMovement>();

        CanvasWidth = CanvasUIElement.GetComponent<RectTransform>().rect.width;
        CanvasHeight = CanvasUIElement.GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    public void GameEnd(string winner)
    {
        if(winner == "left")
        {
            GameObject winnerDisplay1 = Instantiate(leftWinnerDisplay) as GameObject;
            winnerDisplay1.transform.SetParent(canvas.transform, false);
            theWinner = "left";
        }
        else if (winner == "right")
        {
            GameObject winnerDisplay1 = Instantiate(rightWinnerDisplay) as GameObject;
            winnerDisplay1.transform.SetParent(canvas.transform, false);
            theWinner = "right";
        }

        GameObject playAgainButton1 = Instantiate(playAgainButton) as GameObject;
        playAgainButton1.transform.SetParent(canvas.transform, false);
        GameObject returnToMenuButton1 = Instantiate(returnToMenuButton) as GameObject;
        returnToMenuButton1.transform.SetParent(canvas.transform, false);
    }
    public void ResetUI()
    {
        button = GameObject.Find("PlayAgainButton(Clone)");
        Destroy(button);
        button = GameObject.Find("ReturnToMenuButton(Clone)");
        Destroy(button);
        if (theWinner == "left")
        {
            winnerDisplay = GameObject.Find("WinnerAnouncement(Left)(Clone)");
            Destroy(winnerDisplay);
        }
        else if (theWinner == "right")
        {
            winnerDisplay = GameObject.Find("WinnerAnouncement(Right)(Clone)");
            Destroy(winnerDisplay);
        }

        scoreMovement.Reset();
    }
    public void Test()
    {
        UnityEngine.Debug.Log("Working UI");
    }
}
