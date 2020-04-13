using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner;
    public float waitTime = 2f;
    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if (popUpIndex == 0)
        {
            if (Input.touchSupported)
            {
                popUpIndex++;
            }
            else if (popUpIndex == 1)
            {
                if (Input.touchSupported)
                {
                    popUpIndex++;
                }
                else if (popUpIndex == 2)
                {
                    if(waitTime <= 0)
                    {
                       spawner.SetActive(true);
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                    
                }
               
            }
        }
    }
}
