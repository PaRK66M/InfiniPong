using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().ResetUI();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameRestart();
    }
}
