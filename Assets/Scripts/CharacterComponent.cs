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
    [SerializeField] private bool isWalking;

    [Header("Raycast")]
    public float rayLength;
    public float xOffset;

    [Header("Rotating")]
    [SerializeField] private bool isRotating;
    public float rotateSpeed;
    public float downForce;
    private Vector3 mousePosition;
    private Vector2 shootingDirection;
    public Vector2 shootingForce;
    [SerializeField] private bool isMouseDown;
    [SerializeField] private bool backToGround;

    private Rigidbody2D rb;

    private Animator anim;
    private SpriteRenderer sr;

    [Header("Life State")]
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
        if(canMove)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal"); //-1,0,1

            if (IsGrounded(xOffset) || IsGrounded(-xOffset)) //two ray, left and right of the body
            {
                anim.SetBool("OnGround", true);
                backToGround = true;

                if (Input.GetKeyDown(KeyCode.Space) && isRotating == false)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight); //only change y axis

                }

            }
            else
            {
                anim.SetBool("OnGround", false);
                backToGround = false;
            }

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Rotating & Shooting Logic
            if (Input.GetKey(KeyCode.S))
            {
                isRotating = true;
                anim.SetBool("CanRoll", true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                isRotating = true;
                anim.SetBool("CanRoll", true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                isRotating = false;
                anim.SetBool("CanRoll", false);

                //Directly falling to the ground
                if (backToGround == false)
                {
                    //rb.velocity = new Vector2(0, -downForce);
                    rb.velocity = new Vector2(horizontalInput * moveSpeed, -downForce);
                  // Debug.Log(horizontalInput);
                }

            }

            if (Input.GetMouseButtonDown(0) && backToGround && isRotating) //press LMB and you're on ground
            {
                isMouseDown = true;

                //Debug.Log("Shoooooot");
            }

            if(backToGround)
            {
                isWalking = true;
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

    }

    private void FixedUpdate()
    {
        if(canMove && isWalking)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));


            if (horizontalInput != 0)  //flip the character
            {
                transform.localScale = new Vector3(horizontalInput * Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y), Mathf.Abs(transform.localScale.z));
            }

        }

        if (isRotating)
        {
            shootingDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            //Debug.Log(shootingDirection);

            if (isMouseDown)
            {
                isWalking = false;
                rb.AddForce(new Vector2(shootingDirection.normalized.x * shootingForce.x, shootingDirection.normalized.y *shootingForce.y), ForceMode2D.Impulse);
                //Debug.Log(shootingDirection.normalized * shootingForce);
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
