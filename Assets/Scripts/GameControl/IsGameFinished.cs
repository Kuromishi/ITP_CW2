using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGameFinished : MonoBehaviour
{
    public static IsGameFinished Instance;



    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
