using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Animator simplenav;
    public Animator invetoryholder;
    public bool MenuOpen;

    public Evo pc;
    public int tigercup;
    public GameObject inventorytigercup;
    public bool usetigercup;
    public GameObject bluetigercup;
    public bool bonus;

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

        goldText.text = "Gold:" + goldCount;
        tigercup = PlayerPrefs.GetInt("tigercup");

        if (tigercup == 1)
        {
            inventorytigercup.SetActive(true);
        }

        if (usetigercup == true)

        {
            bluetigercup.SetActive(false);
        }
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

    public void Buytigercup()
    {
        goldCount -= 1;
        PlayerPrefs.SetInt("tigercup", 1);
        Shoptigercup.interactable = false;
        
    }

    public void Usetigercup()
    {
        usetigercup = true;
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("tigercup", 0);
        inventorytigercup.SetActive(false);
        usetigercup = false;
    }

}
