using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpeed = 10f;
    SceneController sceneController;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sceneController = FindObjectOfType<SceneController>();
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
            moveSpeed = 0;
            sceneController.EndGame();
        }
    }
    private void OnTriggerEnter2D()
    {
        FindObjectOfType<SceneController>().LevelComplete();
    }
}
