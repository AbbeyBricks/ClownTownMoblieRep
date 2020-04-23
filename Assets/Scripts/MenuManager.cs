using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager: MonoBehaviour
{
    public Animator simplenav;
    public Animator invetoryholder;
    public Animator clownopedia;
    public bool MenuOpen;
    public bool BookOpen;

    public Evo pc;
    public int tigercup;
    public GameObject inventorytigercup;
    public bool usetigercup;
    public bool usepopcorn;
    public bool usenose;
    public GameObject bluetigercup;
    public bool bonus;
    public EnemySpawner es;
    public bool MorePerformersActive; 

    public int goldCount;
    public Text goldText;

    public Button Shoptigercup;
    public Button Shoppopcorn;
    public Button Shopnose;
    // Start is called before the first frame update
    void Start()
    {
        goldCount = PlayerPrefs.GetInt("Gold");

    }

    // Update is called once per frame
    void Update()
    {

        PlayerPrefs.SetInt("Gold", goldCount);

        goldText.text = "money:" + goldCount;
        tigercup = PlayerPrefs.GetInt("tigercup");

        if (tigercup == 1)
        {
            inventorytigercup.SetActive(true);
        }

        if (usetigercup == true)

        {
            if(MorePerformersActive == false)
            {
              StartCoroutine("MorePerformers");
                MorePerformersActive = true;
            }
            

        }

        if (goldCount >= 100 && usetigercup == false)
        {
            Shoptigercup.interactable = true;
        }
        else
        {
            Shoptigercup.interactable = false;
        }



        if (goldCount >= 500 && usepopcorn == false)
        {
            Shoppopcorn.interactable = true;
        }
        else
        {
            Shoppopcorn.interactable = false;
        }


        if (goldCount >= 800 && usenose == false)
        {
            Shopnose.interactable = true;
        }
        else
        {
            Shopnose.interactable = false;
        }
    }
    IEnumerator MorePerformers()
    {
        es.minDelay = 0.1f;
        es.maxDelay = 1f;
        yield return new WaitForSeconds(10);

        es.minDelay = 0.25f;
        es.maxDelay = 5f;

        usetigercup = false;
        MorePerformersActive = false; 
    }


    public void OpenNav()
    {
        if (MenuOpen == false)
        {
            simplenav.SetBool("Open", true);
            Time.timeScale = 0;
            MenuOpen = true;
        }

        else if (MenuOpen == true)
        {
            simplenav.SetBool("Open", false);
            Time.timeScale = 1;
            MenuOpen = false;
        }
    }

    public void CloseNav()
    {
        simplenav.SetBool("Open", false);
        Time.timeScale = 1;
        MenuOpen = false;
    }

    public void OpenInv()
    {
        invetoryholder.SetBool("Open", true);
    }

    public void CloseInv()
    {
        invetoryholder.SetBool("Open", false);
    }





    public void OpenBook()
    {
        if (BookOpen == false)
        {
            clownopedia.SetBool("OpenBook", true);
            Time.timeScale = 0;
            BookOpen = true;
        }

        else if (BookOpen == true)
        {
            clownopedia.SetBool("OpenBook", false);
            Time.timeScale = 1;
            BookOpen = false;
        }
    }

    public void CloseBook()
    {
        clownopedia.SetBool("OpenBook", false);
        Time.timeScale = 1;
        BookOpen = false;
    }




    public void Buytigercup()
    {
        goldCount -= 100;
        Shoptigercup.interactable = false;
        usetigercup = true;
    }

    public void Buypopcorn()
    {
        goldCount -= 500;
        Shoppopcorn.interactable = false;
        usepopcorn = true;
    }

    public void Usetigercup()
    {
        
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("tigercup", 0);
        inventorytigercup.SetActive(false);
        usetigercup = false;

        PlayerPrefs.SetInt("popcorn", 0);
        usepopcorn = false;
    }

}
