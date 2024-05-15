using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myrigidbody2D;
    [SerializeField] float bulletSpeed = 20f;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    
    void Update()
    {
        myrigidbody2D.velocity = new Vector2(xSpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
