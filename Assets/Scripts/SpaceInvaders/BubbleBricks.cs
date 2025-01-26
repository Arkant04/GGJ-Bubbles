using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBricks : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float limite;

    private ParticleSystem particle;
    private Vector3 direction = Vector3.right;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;

        if (transform.position.x >= limite)
        {
            direction = Vector3.left;
        }
        else if (transform.position.x <= -limite)
        {
            direction = Vector3.right;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("bullet1") && collision.CompareTag("Blue"))
        {
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("bullet2") && collision.CompareTag("Red"))
        {
            Destroy(gameObject);
        }
    }
}