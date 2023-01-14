using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTimer : MonoBehaviour
{
    public StraightLaser straightLaser;

    public float coolDownTime1 = 0;
    public float shootTime1 = 2;    
    
    public float coolDownTime2 = 0;
    public float shootTime2 = 2;

    private void Start()
    {
    }

    private void Update()
    {
        if (shootTime1 > 0)
        {
            //straightLaser.canLaser1Start = true;

            shootTime1 -= Time.deltaTime;

            if (shootTime1 <= 0)
            {
                coolDownTime1 = 2;
            }
        }

        if (coolDownTime1 > 0)
        {
            //straightLaser.canLaser1Start = false;

            coolDownTime1 -= Time.deltaTime;

            if (coolDownTime1 <= 0)
            {
                shootTime1 = 2;
            }
        }

        if (shootTime2 > 0)
        {
            //straightLaser.canLaser2Start = true;

            shootTime2 -= Time.deltaTime;

            if (shootTime2 <= 0)
            {
                coolDownTime2 = 3;
            }
        }

        if (coolDownTime2 > 0)
        {
            //straightLaser.canLaser2Start = false;

            coolDownTime2 -= Time.deltaTime;

            if (coolDownTime2 <= 0)
            {
                shootTime2 = 2;
            }
        }
    }

}
