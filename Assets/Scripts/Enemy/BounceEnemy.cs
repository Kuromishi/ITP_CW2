using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEnemy : MonoBehaviour
{
    public Transform targetPlayer;
    public float enemyMoveSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, enemyMoveSpeed * Time.deltaTime);
    }
}
