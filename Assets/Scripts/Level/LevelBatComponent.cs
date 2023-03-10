using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBatComponent : MonoBehaviour
{
    public CharacterComponent characterComponent;

    public GameObject countDown;
    public BatGroupControl batGroupControl;
    public GameObject pauseButton;

    private bool canExit;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.isLevel4DialogueShown == false)
        {
            GameManager.Instance.isLevel4DialogueShown = true;
            pauseButton.SetActive(false);
            StartCoroutine(ShowDialogue());
        }
        else
        {
            characterComponent.canMove = true;
            countDown.SetActive(true);
            pauseButton.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (batGroupControl.levelBatSuccess)
        {
            //exit closed to opened
            canExit = true;
        }

    }

    IEnumerator ShowDialogue()
    {
        characterComponent.canMove = false;

        //Debug.Log("HERE!");

        GameManager.Instance.panelDialogue.SetActive(true);
        GameManager.Instance.panelAnimator.SetBool("canAppear", true);

        //play dialoguePanel animation, show dialogue after that

        yield return new WaitForSeconds(1f);

        GameManager.Instance.dialogueSystem.canPlayDialogue = true;

        yield return new WaitUntil(HasDialogueOver);

        characterComponent.canMove = true;

        //10 seconds countdown
        countDown.SetActive(true);
        pauseButton.SetActive(true);

        yield return null;
    }

    bool HasDialogueOver()
    {
        if (GameManager.Instance.dialogueSystem.canPlayDialogue == false)
        {
            return true;
        }
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<CharacterComponent>() != null && canExit)
        {
            GameManager.Instance.isLevel4Finished = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
