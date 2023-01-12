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
    private float minX, minY, maxX, maxY;
    public Transform moveSpot;
    private float waitTime;
    public float startWaitTime;

    //Enemy random movement reference: https://www.bilibili.com/video/BV1MJ411X7v4/?spm_id_from=333.337.search-card.all.click&vd_source=492886e5fdb8fffe95e1f3e89e81ae89

    private void Start()
    {
        anim_Bat = GetComponent<Animator>();
        batRB = GetComponent<Rigidbody2D>();
        batRenderer = GetComponent<SpriteRenderer>();
        batRB.gravityScale = 0;

        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        waitTime = startWaitTime;

        minX = transform.position.x - 2;
        minY = transform.position.y - 2;
        maxX = transform.position.x + 2;
        maxY = transform.position.y + 2;


    }

    private void Update()
    {
        //move randomly in a specific area
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, batMoveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot.position)<0.2f)
        {
            if(waitTime<=0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
                if(transform.position.x - moveSpot.position.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
                
            }
        }

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

        if (collision.CompareTag("MapCollider"))
        {
            moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

    }
}
