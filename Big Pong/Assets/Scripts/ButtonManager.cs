using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    int n;
    public void OnButtonPress()
    {
        n++;
        UnityEngine.Debug.Log("Button clicked " + n + " times.");
    }
}
