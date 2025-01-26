using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPl2 : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;
    Rigidbody2D rb;
    bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isGrounded && Input.GetKey(KeyCode.RightControl))
        {
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.SetActive(false);
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
