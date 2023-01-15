using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6Component : MonoBehaviour
{
    public CharacterComponent characterComponent;

    public GameObject pauseButton;
    public GameObject hugeMonsterObject;
    public GameObject playerCharacter;
    public GameObject sparkParticle;

    private bool canLoadScene;

    AudioSource monsterAudioSource;
    public AudioClip monster_AudioClip;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.SetActive(false);
        StartCoroutine(ShowDialogue());
        monsterAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canLoadScene)
        {
            SceneManager.LoadScene(0);
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

        pauseButton.SetActive(true);


        yield return new WaitForSeconds(1f);
        //Final 

        playerCharacter.SetActive(false);
        sparkParticle.SetActive(true);
        yield return new WaitForSeconds(2f);

        hugeMonsterObject.SetActive(true);
        monsterAudioSource.clip = monster_AudioClip;
        monsterAudioSource.Play();

        yield return new WaitForSeconds(2.7f);

        canLoadScene = true;

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


}
