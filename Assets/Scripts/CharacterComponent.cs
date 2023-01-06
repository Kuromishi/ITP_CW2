using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    [Header("Movement")]
    private float horizontalInput;
    public float moveSpeed;
    public float jumpHeight;


    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        

    }

    private void FixedUpdate()
    {
        Move(horizontalInput, 1);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight); //only change y axis
            //anim.SetBool
        }
    }

    public void Move(float direction, int isFlip) //direction=horizontalInput;
    {
        if (direction < 0)
        {
            sr.flipX = true;                  
        }

        if (direction > 0)
        {
            sr.flipX = false;
        }

        rb.velocity = new Vector2(isFlip * direction * moveSpeed, rb.velocity.y); 

        anim.SetFloat("Speed", Mathf.Abs(direction));     //direction > 0, idle to walk£» direction < 0£¬walk to idle.

    }



}
