using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{
    [Header("Textfile")]
    public TextAsset level2_TextFile;
    public TextAsset level3_TextFile;
    public TextAsset level4_TextFile;
    public TextAsset level5_TextFile;
    public TextAsset level6_TextFile;

    [Header("Other Settings")]
    public DialogueSystem dialogueSystem;

    public enum LevelState
    {
        NoLevel,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6
    }

    [Header("Level State")]
    public LevelState levelState = LevelState.NoLevel;

    private void Update()
    {
        if(GameManager.Instance.isLevel1Finished)
            levelState = LevelState.Level2;

        if(GameManager.Instance.isLevel2Finished)
            levelState = LevelState.Level3;

        if(GameManager.Instance.isLevel3Finished)
            levelState = LevelState.Level4;

        switch (levelState)
        {
            case LevelState.Level2:

                dialogueSystem.textFile = level2_TextFile;

                break;

            case LevelState.Level3:

                dialogueSystem.textFile = level3_TextFile;

                break;

            case LevelState.Level4:

                dialogueSystem.textFile = level4_TextFile;

                break;            
            
            case LevelState.Level5:

                dialogueSystem.textFile = level5_TextFile;

                break;            
            
            case LevelState.Level6:

                dialogueSystem.textFile = level6_TextFile;

                break;

        }
    }
}
