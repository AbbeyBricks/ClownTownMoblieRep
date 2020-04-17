using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbWatcher : MonoBehaviour
{
    public GameObject[] absorbs;
    public bool popcorn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        absorbs = GameObject.FindGameObjectsWithTag("absorb");

        if (popcorn == true)
        {
            for (int i = 0; i < absorbs.Length; i++)
            {
                absorbs[i].GetComponent<GotHit>().popcorn = true;
            }
        }
        else
        {

        }
    }
}
