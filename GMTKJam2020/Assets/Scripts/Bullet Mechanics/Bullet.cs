using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    public Vector2 moveDir;
    [SerializeField] private LayerMask wallLayer;
    private objectPuller puller;
    private static playerController player;
    private static enemyHealth enemy;
    
    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemy>();
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent < enemyHealth>();
        rb.velocity = moveDir * speed;
        puller = objectPuller.Instance;
    }

    public void launch()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = moveDir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb = GetComponent<Rigidbody2D>();

        if (collision.gameObject.layer == 8)
        {
            Vector2 wallNormal = collision.contacts[0].normal;
            moveDir = Vector2.Reflect(moveDir, wallNormal);
            rb.velocity = moveDir * speed;

        }
        else if (collision.collider.CompareTag("Player"))
        {
            //player losing health
            collision.gameObject.GetComponent<playerController>().health--;
            //Debug.Log(player.health);
            puller.poolDictionary[tag].Enqueue(this.gameObject);
            this.gameObject.SetActive(false);

        }

        else if (collision.collider.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemyHealth>().health--;
            puller.poolDictionary[tag].Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }

    }

}


        
