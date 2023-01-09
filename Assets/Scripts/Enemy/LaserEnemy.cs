using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public float speed = 80f;
    private bool isShooting;

    [Header("Raycast")]
    public LineRenderer laserLine1;
    public Transform firePoint1;
    public LineRenderer laserLine2;
    public Transform firePoint2;
    public LineRenderer laserLine3;
    public Transform firePoint3;
    public LineRenderer laserLine4;
    public Transform firePoint4;
    public float maxDistance;
    public LayerMask layerMask;

    private void Start()
    {

        isShooting = true;
    }

    private void Update()
    {
        transform.Rotate(-Vector3.forward * Time.deltaTime * speed);

        if (isShooting)
        {
            ShootLaser(laserLine1, firePoint1);
            ShootLaser(laserLine2, firePoint2);
            ShootLaser(laserLine3, firePoint3);
            ShootLaser(laserLine4, firePoint4);

        }
    }

    public void ShootLaser(LineRenderer laserLine, Transform firePoint )
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, maxDistance,layerMask);
        
        laserLine.enabled = true;

        laserLine.SetPosition(0, firePoint.position);
        laserLine.SetPosition(1, hitInfo.point);

        

        if(hitInfo.collider.gameObject.GetComponent<CharacterComponent>()!=null)  //hit the player
        {
            Debug.Log("Player Died!");
        }
    }
}
