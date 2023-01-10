using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Level State")]
    public bool isLevel1Finished;
    public bool isLevel2Finished;
    public bool isLevel3Finished;

    [Header("Whether Show Dialogue")]
    public bool isLevel2DialogueShown;
    public bool isLevel3DialogueShown;
    public bool isLevel4DialogueShown;

    [Header("Dialogue System")]
    public DialogueSystem dialogueSystem;
    public GameObject panelDialogue;
    public Animator panelAnimator;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
