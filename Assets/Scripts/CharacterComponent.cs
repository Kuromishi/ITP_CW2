using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterComponent : MonoBehaviour
{
    [Header("Movement")]
    private float horizontalInput;
    public float moveSpeed;
    public float jumpHeight;
    public bool canMove;

    public float rayLength;
    public float xOffset;

    private Rigidbody2D rb;

    private Animator anim;
    private SpriteRenderer sr;

    public bool isPlayerDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //canMove = true;
        isPlayerDead = false;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (IsGrounded(xOffset) || IsGrounded(-xOffset)) //two ray, left and right of the body
        {
            anim.SetBool("OnGround", true);
            if (Input.GetKeyDown(KeyCode.Space) && canMove)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight); //only change y axis

            }
        }
        else
            anim.SetBool("OnGround", false);

        if(isPlayerDead)
        {
            //Debug.Log("You are dead");
            canMove = false;

            anim.SetBool("IsDead", true);

            //Reload after character dead animation over
            Invoke("ReloadScene", 3);

        }

    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));


            if (horizontalInput != 0)  //flip the character
            {
                transform.localScale = new Vector3(horizontalInput * Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y), Mathf.Abs(transform.localScale.z));
            }
        }

        //Move(horizontalInput, 1);

    }

    public bool IsGrounded(float offsetX)
    {
        Vector2 rayStart = new Vector2(transform.position.x + offsetX, transform.position.y);  //Define the starting point of the ray

        Debug.DrawRay(rayStart, Vector2.down * rayLength, Color.red); //check what the ray really looks like in the scene

        RaycastHit2D ray = Physics2D.Raycast(rayStart, Vector2.down, rayLength);

        if (ray.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //reload current scene
    }

}
