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
    public bool isRotating;
    public bool canJump;

    public float rayLength;
    public float xOffset;

    public float rotateSpeed;

    private Vector3 mousePosition;
    private Vector2 shootingDirection;
    public float shootingForce;
    [SerializeField] private bool isMouseDown;
    [SerializeField] private bool backToGround;

    private Rigidbody2D rb;

    private Animator anim;
    private SpriteRenderer sr;

    [Header("State")]
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
            backToGround = true;

            if (Input.GetKeyDown(KeyCode.Space) && canMove && isRotating==false)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight); //only change y axis

            }

        }
        else
        {
            anim.SetBool("OnGround", false);
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetKey(KeyCode.S) && canMove)
        {
            isRotating = true;
            anim.SetBool("CanRoll", true);
        }
        else if(Input.GetKeyDown(KeyCode.S) && canMove)
        {
            isRotating = true;
            anim.SetBool("CanRoll", true);
        }
        else if(Input.GetKeyUp(KeyCode.S) && canMove)
        {
            isRotating = false;
            anim.SetBool("CanRoll", false);
        }

        if(Input.GetMouseButtonDown(0)&& backToGround) //press LMB and you're on ground
        {
            isMouseDown = true;

            //Debug.Log("Shoooooot");
        }


        if (isPlayerDead)
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
        if (isRotating)
        {
            shootingDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            //Debug.Log(shootingDirection);

            if (isMouseDown)
            {
                rb.AddForce(shootingDirection * shootingForce, ForceMode2D.Impulse);
                backToGround = false;
                isMouseDown = false;
            }

        }
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
