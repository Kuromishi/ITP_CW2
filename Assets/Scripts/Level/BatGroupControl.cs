using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatGroupControl : MonoBehaviour
{
    public GameObject batEmeny1;
    public GameObject batEmeny2;
    public GameObject batEmeny3;

    public bool levelBatSuccess;

    public DoorOpen doorOpen;

    private void Update()
    {
        if(!batEmeny1.activeSelf && !batEmeny2.activeSelf && !batEmeny3.activeSelf)
        {
            //Debug.Log("Bat Died");
            //when all the four bats died in 10 seconds...the exit is active
            levelBatSuccess = true;
            doorOpen.canBannerDisappear = true;
        }
    }
}
