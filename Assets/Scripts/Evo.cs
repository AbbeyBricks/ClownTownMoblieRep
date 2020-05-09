using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evo : MonoBehaviour

{
    public Image evobar1;
    public Image evobar2;
    public Image evobar3;
    public float evo1;
    public float evo2;
    public float current;
    public Animator anim;
    public bool evo1complete;
    public bool evo2complete;
    public bool bonus;

    public int money;
    public int clowns;
    public GameObject gold;
    public EnemySpawner goldSpawner;

    public GameObject NewClownFound;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (clowns >= 10)
        {
            gold.SetActive(true);
            StartCoroutine(ActivateGold());
            clowns = 0;
        }

        evobar1.fillAmount = (current / evo1);
        evobar2.fillAmount = (current / evo2);

        if (evobar1.fillAmount == 1 && evo1complete == false)
        {
            current = 0;
            // you can aslo enable text that say "To Next EVO"
            evobar1.enabled = false;
            evobar2.enabled = true;
            anim.SetBool("evo1", true);
            evo1complete = true;
            StartCoroutine("NewClown");

        }

        if (evobar2.fillamount == 1 && evo2complete == false)
        {
            current = 0;
            evobar2.enabled = false;
            evobar3.enabled = true;
            anim.SetBool("evo2", true);
            evo2complete = true;
            //StartCoroutine("NewClown2");
        }

        if (evobar3.fillAmount == 1)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }

        IEnumerator NewClown()
        {
            newclownfound.SetActive(true);
            yield return new WaitForSeconds(2f);
            newclownfound.setactive(false);
        }
        IEnumerator ActivateGold()
        {
            goldSpawner.StartCoroutine("SpawnEnemies");
            yield return new WaitForSeconds(5f);
            gold.SetActive(false);

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "absorb")
            {
                if (bonus == false)
                {
                    current += 1;
                    clowns += 1;
                    StartCoroutine("kick");
                }
                else if (bonus == true)
                {
                    current += 2;
                    money += 2;
                    StartCoroutine("absorb");
                }

            }


        }

        void StartBonusTime()
        {
            StartCoroutine(BonusTime());
        }

        IEnumerator BonusTime()
        {
            bonus = true;
            yield return new WaitForSeconds(5f);
            bonus = false;
        }

        IEnumerator Kick()
        {
            anim.SetBool("kick", true);
            yield return new WaitForSeconds(.5F);
            anim.SetBool("kick", false);
        }

        IEnumerator Absorb()
        {
            anim.SetBool("Absorb", true);
            yield return new WaitForSeconds(.5f);
            anim.SetBool("Absorb", false);
        }
    }
}