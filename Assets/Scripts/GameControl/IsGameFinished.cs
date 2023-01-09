using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGameFinished : MonoBehaviour
{
    public static IsGameFinished Instance;

    public bool isLevel1Finished;
    public bool isLevel2Finished;
    public bool isLevel3Finished;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

    }
}
