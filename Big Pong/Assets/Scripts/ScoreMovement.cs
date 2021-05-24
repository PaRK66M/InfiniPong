using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMovement : MonoBehaviour
{
    public Canvas CanvasUIElement;//Set in editor
    private float CanvasWidth;
    private float CanvasHeight;
    Image image;
    RectTransform rt;
    float numHolder;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
        CanvasWidth = CanvasUIElement.GetComponent<RectTransform>().rect.width;
        CanvasHeight = CanvasUIElement.GetComponent<RectTransform>().rect.height;
        rt.sizeDelta = new Vector2(CanvasWidth / 5, 2);
        numHolder = CanvasWidth / 5;
    }

    public void MoveLeft(string color)
    {       
        if(color == "white")
        {
            image.color = Color.white;
        }
        else if(color == "red")
        {
            image.color = Color.red;
        }
        else if (color == "black")
        {
            image.color = Color.black;
        }
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x - numHolder, 0);
    }

    public void MoveRight(string color)
    {
        if (color == "white")
        {
            image.color = Color.white;
        }
        else if (color == "red")
        {
            image.color = Color.red;
        }
        else if (color == "black")
        {
            image.color = Color.black;
        }
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x + numHolder, 0);
    }

    public void Reset()
    {
        rt.anchoredPosition = new Vector2(0, 0);
        image.color = Color.white;
    }
}
