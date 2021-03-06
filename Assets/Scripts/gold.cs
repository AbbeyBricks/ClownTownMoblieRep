﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{
    public Evo ev;
    public Rigidbody2D rb2d;
    public float power;
    public float powerup;
    public float fallspeed;
    public MenuManager mm;
    public AudioSource goldsound;

    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindObjectOfType<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ev = GameObject.FindObjectOfType<Evo>();
        rb2d.velocity = new Vector2(power, (powerup -= (Time.deltaTime * fallspeed)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            powerup = 10;
            MF_AutoPool.Despawn(this.gameObject);
            mm.goldCount += 1;
            goldsound.Play();
            //ev.money += 1;
            
            
        }
        if (collision.tag == "Catcher")
        {
            powerup = 10;
            MF_AutoPool.Despawn(this.gameObject);
        }
    }

}
