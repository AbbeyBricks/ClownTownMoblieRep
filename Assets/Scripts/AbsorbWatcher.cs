using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbWatcher : MonoBehaviour
{
    public GameObject[] absorbs;
    public bool popcorn;
    public MenuManager mm;
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
            for (int i = 0; i < absorbs.Length; i++)
            {
                absorbs[i].GetComponent<GotHit>().popcorn = false;
            }
        }
    }

    public void PopcornStart()
    {
        StartCoroutine("UsePopCorn");
        mm.goldCount -= 500;
        mm.Shoppopcorn.interactable = false;
    }

    public IEnumerator UsePopCorn()
    {
        popcorn = true;
        yield return new WaitForSeconds(10f);
        popcorn = false;
    }
}
