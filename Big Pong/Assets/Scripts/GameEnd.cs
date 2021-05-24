using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Canvas CanvasUIElement;//Set in editor
    private float CanvasWidth;
    private float CanvasHeight;
    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        CanvasWidth = CanvasUIElement.GetComponent<RectTransform>().rect.width;
        CanvasHeight = CanvasUIElement.GetComponent<RectTransform>().rect.height;
        rt.sizeDelta = new Vector2(CanvasWidth - (CanvasWidth / 5), CanvasHeight  - (CanvasHeight / 5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
