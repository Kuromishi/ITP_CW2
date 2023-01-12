using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public Transform targetPlayer;
    public float bossMoveSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, bossMoveSpeed * Time.deltaTime);
    }
}
