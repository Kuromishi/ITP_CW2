using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform movingPoint1;
    public Transform movingPoint2;
    public Transform movingPlatform;

    [Range(0, 1)]
    [SerializeField] private float T = 1;

    private bool switchDir;

    private void Update()
    {
        //use Timer to change the position of moving platform to make it moving the fixed two points
        if(switchDir)
        {
            T -= 0.5f * Time.deltaTime;
            if (T <= 0)
            {
                switchDir = false;
            }
        }
        else
        {
            T += 0.5f * Time.deltaTime;
            if (T >= 1)
            {
                switchDir = true;
            }
        }
        movingPlatform.position = Vector3.Lerp(movingPoint1.position, movingPoint2.position, T);
    }

       

}
