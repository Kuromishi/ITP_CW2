using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornKill : MonoBehaviour
{
    public CharacterComponent characterComponent;
    //public bool canDown;
    private Animator anim_Thorn;
    AudioSource thornAudioSource;
    public AudioClip down_ThornClip;

    private void Start()
    {
        //canDown = false;
        anim_Thorn = GetComponent<Animator>();
        thornAudioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        //if(canDown)
        //{
            anim_Thorn.SetBool("canFall", true);

        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponentInParent<CharacterComponent>()!=null)
        {
            characterComponent.isPlayerDead = true;

            thornAudioSource.clip = down_ThornClip;
            thornAudioSource.Play();
        }
    }
}
