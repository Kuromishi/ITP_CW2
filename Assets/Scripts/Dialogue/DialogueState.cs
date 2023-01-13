using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{
    [Header("Textfile")]
    public TextAsset level2_TextFile;
    public TextAsset level3_TextFile;
    public TextAsset levelBat_TextFile;

    [Header("Other Settings")]
    public DialogueSystem dialogueSystem;

    public enum LevelState
    {
        NoLevel,
        Level2,
        Level3,
        LevelBat
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
            levelState = LevelState.LevelBat;

        switch (levelState)
        {
            case LevelState.Level2:

                dialogueSystem.textFile = level2_TextFile;
                break;

            case LevelState.Level3:

                dialogueSystem.textFile = level3_TextFile;

                break;


            case LevelState.LevelBat:

                dialogueSystem.textFile = levelBat_TextFile;

                break;

        }
    }
}
