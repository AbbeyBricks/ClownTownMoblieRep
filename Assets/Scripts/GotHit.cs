using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHit : MonoBehaviour
{
    public GameObject mover;
    public MovingObject mo;
    public Animator anim;
    public Evo ev;
    public bool hit;
    public SpriteRenderer sr;
    public CircleCollider2D b2;
    public Transform start;
    public bool popcorn;
    public AudioSource hitsound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ev = GameObject.FindObjectOfType<Evo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(popcorn == false)
        {
         if(collision.tag == "Player" && hit == false)
                {
                    mo.enabled = false;
                    anim.SetBool("fall", true);
                ev.StartCoroutine("Player_kick");
                hitsound.Play();
                    StartCoroutine(Vulnerable());
                }

                if(collision.tag == "Player" && hit == true)
                {
                    StartCoroutine(Finish());
                ev.StartCoroutine("Absorb");
                }
        }

        else
        {
            if (collision.tag == "Player")
            {
                StartCoroutine(Finish());
            }
        }


       
    }
    IEnumerator Vulnerable()
    {
        b2.enabled = false;
        yield return new WaitForSeconds(2f);
        b2.enabled = true;
        hit = true;

    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("fall", false);
        hit = false;
        transform.position = start.position;
        mo.enabled = true;
        MF_AutoPool.Despawn(mover);
    }
 
}
