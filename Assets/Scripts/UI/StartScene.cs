using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.isLevel1Finished = false;
        GameManager.Instance.isLevel2Finished = false;
        GameManager.Instance.isLevel3Finished = false;
        GameManager.Instance.isLevel2DialogueShown = false;
        GameManager.Instance.isLevel2DialogueShown = false;
        GameManager.Instance.isLevel2DialogueShown = false;
    }
    public void ContinueGame()
    {
        if(GameManager.Instance.isLevel1Finished)
        {
            SceneManager.LoadScene(2);
        }
        if (GameManager.Instance.isLevel2Finished)
        {
            SceneManager.LoadScene(3);
        }
        //if (GameManager.Instance.isLevel3Finished)
        //{
        //    SceneManager.LoadScene(4);
        //}
    }
}
