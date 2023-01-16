using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueSystem : MonoBehaviour
{

    //Create the dialogue System reference: https://www.bilibili.com/video/BV1WJ411Y71J/?spm_id_from=333.337.search-card.all.click
    public Text textLabel;
    public TextAsset textFile;
    public int index;

    public float textSpeed;
    private bool textFinished;
    private bool cancelTyping;

    public bool canPlayDialogue;

    public List<string> textList = new List<string>();

    //public CharacterComponent characterComponent;

    void Awake()
    {

    }
    private void OnEnable() //OnEnable is called before Start
    {
        //textLabel.text = textList[index];
        //index++;
        if (textFile)  //if textFile exists
        {
            GetTextFromFile(textFile);
        }

        StartCoroutine(MovingTextUI());

        //characterComponent.canMove = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && index == textList.Count && canPlayDialogue) //the last part
        {
            gameObject.SetActive(false);
            index = 0;
            canPlayDialogue = false;
            //characterComponent.canMove = false;
            
        }


        if (Input.GetKeyDown(KeyCode.E)&& canPlayDialogue)
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(MovingTextUI());
            }
            else if (!textFinished) //coroutine is starting
            {
                cancelTyping = !cancelTyping; 
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator MovingTextUI()
    {
        textFinished = false;  //start the second lines when the first one is over 
        textLabel.text = ""; //clear the list



        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }

        textLabel.text = textList[index];
        cancelTyping = false;

        textFinished = true;
        index++;
    }

}
