using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evo : MonoBehaviour

{
    public Image evobar1;
    public Image evobar2;
    public float evo1;
    public float evo2;
    public float current;
    public Animator anim;
    public bool evo1complete;
    public bool bonus;

    public int money;
    public int clowns;
    public GameObject gold;
    public EnemySpawner goldSpawner;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(clowns >= 10)
        {
            gold.SetActive(true);
            StartCoroutine(ActivateGold());
            clowns = 0;
        }
            
        evobar1.fillAmount = (current / evo1);
        evobar2.fillAmount = (current / evo2);

        if(evobar1.fillAmount == 1 && evo1complete == false)
        {
            current = 0;
            // you can aslo enable text that say "To Next EVO"
            evobar1.enabled = false;
            evobar2.enabled = true;
            anim.SetBool("evo1", true);
            evo1complete = true;

        }
    }

    IEnumerator ActivateGold()
    {
        goldSpawner.StartCoroutine("SpawnEnemies");
        yield return new WaitForSeconds(5f);
        gold.SetActive(false);
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "absorb")
        {
            if (bonus == false)
            {
                current += 1;
                clowns += 1;
            }
            else if (bonus == true)
            {
                current += 2;
                money += 2;
            }
       
        }


    }

    public void StartBonusTime()
    {
        StartCoroutine(BonusTime());
    }

    IEnumerator BonusTime()
    {
        bonus = true;
        yield return new WaitForSeconds(5f);
        bonus = false;
    }
}
