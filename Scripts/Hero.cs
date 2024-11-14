using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Hero : MonoBehaviour
{
    [SerializeField] private float spend = 3f; 
    [SerializeField] private int lives = 1; 
    [SerializeField] private float jumpForce = 15f;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    public static Hero Instance { get; set; }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

  private void Awake()
{
    if (Instance == null)
    {
        Instance = this; 
    }
    else
    {
        Debug.LogWarning("Multiple instances of Hero detected!"); 
    }

    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sprite = GetComponentInChildren<SpriteRenderer>();
}

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = States.idle;
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();

        CheckFallOutOfBounds(); 
    }

    private void Run()
    {
        if (isGrounded) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, spend * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.8f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.jump;
    }

    public void GetDamage()
    {
        lives -= 1;
        Debug.Log("hit"); 
        Debug.Log(lives); 

        if (lives <= 0)
        {
            SceneManager.LoadScene("UnsuccessScreen"); 
        }
    }

    private void CheckFallOutOfBounds()
    {
        if (transform.position.y < -5) 
        {
            GetDamage();
        }
    }
}

public enum States
{
    idle,
    run,
    jump
}
