using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToLevel3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponentInParent<CharacterComponent>() != null)
        {
            IsGameFinished.Instance.isLevel2Finished = true;
            ToNextLevel();
            // Invoke("ToNextLevel", 3);
        }
    }

    private void ToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
