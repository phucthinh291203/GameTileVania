using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    Rigidbody2D enemyRidbody;
    
    void Start()
    {
        enemyRidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        enemyRidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemySprite();
    }

    void FlipEnemySprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(enemyRidbody.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale =new Vector2 (-(Mathf.Sign(enemyRidbody.velocity.x)),1f);
        }
    }
}
