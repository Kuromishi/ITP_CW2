using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornKill : MonoBehaviour
{
    public CharacterComponent characterComponent;
    public bool canDown;
    private Animator anim_Thorn;

    private void Start()
    {
        canDown = false;
        anim_Thorn = GetComponent<Animator>();
    }

    public void Update()
    {
        if(canDown)
        {
            anim_Thorn.SetBool("canFall", true);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponentInParent<CharacterComponent>()!=null)
        {
            characterComponent.isPlayerDead = true;
        }
    }
}
