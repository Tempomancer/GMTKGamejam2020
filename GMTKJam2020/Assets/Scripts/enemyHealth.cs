using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health = 1;
    private playerController player;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<playerController>();

    }

    // Update is called once per frame
    void Update()
    { 
       if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            //player losing health
            other.gameObject.GetComponent<playerController>().health--;
            Debug.Log(player.health);
            Destroy(this.gameObject);
        }
        
    }
}

