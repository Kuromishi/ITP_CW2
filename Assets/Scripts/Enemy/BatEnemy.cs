using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BatEnemy : MonoBehaviour
{
    [Header("Death")]
    private Animator anim_Bat;
    public GameObject batBlood;
    private Rigidbody2D batRB;
    private SpriteRenderer batRenderer;
    private bool canBatDisappear;
    public float disappearSpeed;

    [Range(0,1)]
    private float T=0;

    [Header("Irregular movement")]
    public float batMoveSpeed;


    private void Start()
    {
        anim_Bat = GetComponent<Animator>();
        batRB = GetComponent<Rigidbody2D>();
        batRenderer = GetComponent<SpriteRenderer>();
        batRB.gravityScale = 0;
    }
    private void Update()
    {
        //move randomly in a specific area


        //bat drop to the ground, and gradually disappear
        if (canBatDisappear)
        {
            T += disappearSpeed * Time.deltaTime;
            Color color = batRenderer.color;
            color.a = Mathf.Lerp(1, 0, T);
           // Debug.Log(T);
            batRenderer.color = color;

            if (color.a == 0)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<CharacterComponent>() != null)
        {
            anim_Bat.SetBool("IsBatDead", true);
            batRB.gravityScale = 1;
            //Instantiate(batBlood, gameObject.transform);
            batBlood.SetActive(true);

        }
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            canBatDisappear = true;
            //Debug.Log("BatOnGround");
        }
    }
}
