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
    public bool isLevel4Finished;    
    public bool isLevel5Finished;
    public bool isLevel6Finished;

    [Header("Whether Show Dialogue")]
    public bool isLevel2DialogueShown;
    public bool isLevel3DialogueShown;
    public bool isLevel4DialogueShown;
    public bool isLevel5DialogueShown;
    public bool isLevel6DialogueShown;

    [Header("Dialogue System")]
    public DialogueSystem dialogueSystem;
    public GameObject panelDialogue;
    public Animator panelAnimator;

    [Header("Cursor")]
    public Texture2D clickTexture;
    public Texture2D upTexture;

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

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(clickTexture, Vector2.zero, CursorMode.Auto);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(upTexture, Vector2.zero, CursorMode.Auto);
        }
    }
}
