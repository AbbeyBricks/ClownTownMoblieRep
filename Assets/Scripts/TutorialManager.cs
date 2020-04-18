using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner;
    public GameObject spawnItem;
    public float waitTime = 2f;

 
    private void Update()

    {
        Touch touch = Input.GetTouch(0);
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
            if (touch.phase == TouchPhase.Began) 
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
