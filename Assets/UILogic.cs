using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour
{
    public GameObject pauseUI;

    private void Start()
    {
        //no use, only once when in DONTDESTROYONLOAD
    }

    public void PauseGame()
    {
        //Debug.Log("Game Paused!");
        Time.timeScale = 0;
        
        pauseUI.SetActive(true);
    }
    public void BackToStartScene()
    {
        SceneManager.LoadScene(0);
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void Continue()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }
}
