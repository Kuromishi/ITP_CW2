using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLaser : MonoBehaviour
{
    public CharacterComponent characterComponent;

    public bool canLaserStart;
    //public bool canLaser1Start;
    //public bool canLaser2Start;

    public LineRenderer laserLine1;
    public Transform firePoint1;
    public LineRenderer laserLine2;
    public Transform firePoint2;
    public float maxDistance;
    public LayerMask layerMask;
    public ParticleSystem laserParticle1;
    public ParticleSystem laserParticle2;

    AudioSource straightLaserAudioSource;
    public AudioClip laserClip;

    private void Start()
    {
        canLaserStart = true;
        straightLaserAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (canLaserStart)
        {
            //if(canLaser1Start)
            ShootLaser(laserLine1, firePoint1, laserParticle1);


            //if(canLaser2Start)
            ShootLaser(laserLine2, firePoint2, laserParticle2);



        }
    }

    public void ShootLaser(LineRenderer laserLine, Transform firePoint, ParticleSystem laserParticle)
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, maxDistance, layerMask);

        laserLine.enabled = true;

        laserLine.SetPosition(0, firePoint.position);
        laserLine.SetPosition(1, hitInfo.point);

        laserParticle.transform.position = hitInfo.point;
        laserParticle.Play();
        straightLaserAudioSource.clip = laserClip;
        straightLaserAudioSource.Play();

        if (hitInfo.collider.gameObject.GetComponentInParent<CharacterComponent>() != null)  //hit the player
        {
            // Debug.Log("Player Died!");
            characterComponent.isPlayerDead = true;
        }
    }
}
