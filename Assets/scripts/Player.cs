using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpeed = 10f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            /*
            if (Input.GetKeyDown("Space"))
            {*/
                //Debug.Log("AAA");
                movement = Vector2.zero;
            //}
            //movement.enabled = false;
            //FindObjectOfType<GameManager>().EndGame();
        }
    }
    private void OnTriggerEnter2D()
    {
        FindObjectOfType<SceneController>().LevelComplete();
    }
}
