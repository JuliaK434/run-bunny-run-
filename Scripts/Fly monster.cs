using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flymonster : Entity
{
    private float speed = 2.0f; // Adjust speed as needed
    private Vector3 direction;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float changeDirectionTime = 2.0f; // Time interval to change direction
    private float timeSinceLastChange = 0.0f;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ChangeDirection();
    }

    private void Update()
    {
        Move();
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange >= changeDirectionTime)
        {
            ChangeDirection();
            timeSinceLastChange = 0.0f;
        }
    }

    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
        
    }

    private void ChangeDirection()
    {
        // Randomly change direction
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
        else
        {
            // Reverse direction on collision with other objects
            direction *= -1;
        }
    }
}