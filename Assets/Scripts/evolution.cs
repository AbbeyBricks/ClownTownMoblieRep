using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evolution : MonoBehaviour
{
    public int red;
    public int green;
    public int blue;

    public int total;
    public Animator anim;

    public bool canRed;
    public bool canGreen;
    public bool canBlue;

    public int maxBlue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        total = red + green + blue;

        //Single Evo 

        if (red > 5)
        {
            canRed = true;
        }

        if(green > 5)
        {
            canGreen = true;
        }

        if(blue > maxBlue)
        {
            canBlue = true;
        }

        if ((red/total)>= .75f && canRed)

            {
            anim.SetBool("evo1", true);
            anim.SetBool("evo2", false);
            anim.SetBool("evo3", false);

            if (red > 250)
            {
                anim.SetBool("evo1A", true);
            }
        }
    }
}
