using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBatComponent : MonoBehaviour
{
    public GameObject batEmeny1;
    public GameObject batEmeny2;
    public GameObject batEmeny3;
    public GameObject batEmeny4;

    private void Update()
    {
        if(!batEmeny1.activeSelf && !batEmeny2.activeSelf && !batEmeny3.activeSelf && !batEmeny4.activeSelf)
        {
            //Debug.Log("Bat Died");
            //when all the four bats died in 10 seconds...the exit is active

        }
    }
}
