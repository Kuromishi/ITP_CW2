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

    public CharacterComponent characterComponent;

    [Header("Feedback")]
    public ParticleSystem laserParticle1;
    public ParticleSystem laserParticle2;
    public ParticleSystem laserParticle3;
    public ParticleSystem laserParticle4;

    private void Start()
    {

        isShooting = true;
    }

    private void Update()
    {
        transform.Rotate(-Vector3.forward * Time.deltaTime * speed);

        if (isShooting)
        {
            ShootLaser(laserLine1, firePoint1, laserParticle1);
            ShootLaser(laserLine2, firePoint2, laserParticle2);
            ShootLaser(laserLine3, firePoint3, laserParticle3);
            ShootLaser(laserLine4, firePoint4, laserParticle4);

        }
    }

    public void ShootLaser(LineRenderer laserLine, Transform firePoint, ParticleSystem laserParticle )
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, maxDistance,layerMask);
        
        laserLine.enabled = true;

        laserLine.SetPosition(0, firePoint.position);
        laserLine.SetPosition(1, hitInfo.point);

        laserParticle.transform.position = hitInfo.point;
        laserParticle.Play();


        if (hitInfo.collider.gameObject.GetComponentInParent<CharacterComponent>()!=null)  //hit the player
        {
            // Debug.Log("Player Died!");
            characterComponent.isPlayerDead = true;
        }
    }
}
