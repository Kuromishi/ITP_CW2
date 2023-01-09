using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Countdown : MonoBehaviour
{
    private float totalTime = 10;
    private float intervalTime = 1;

    public Text TenCountDownText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TenCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TenCountDown()
    {
        while(totalTime>0)
        {
            TenCountDownText.text = string.Format("{0:D1}", (int)totalTime);
            yield return new WaitForSeconds(1);
            totalTime--;

            if(totalTime==0) //print the 0
            {
                TenCountDownText.text = string.Format("{0:D1}", (int)totalTime);
            }
        }

    }
}