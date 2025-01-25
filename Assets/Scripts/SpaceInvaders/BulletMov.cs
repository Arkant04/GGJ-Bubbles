using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    public GameObject cubeY;
    public GameObject cubeZ;
    public float speedY = 150f;
    public float speedZ = 200f;

    void Update()
    {
        RotateCubes();
    }

    void RotateCubes()
    {
        if (cubeY != null)
        {
            cubeY.transform.Rotate(Vector3.up * speedY * Time.deltaTime);
        }
        if (cubeZ != null)
        {
            cubeZ.transform.Rotate(Vector3.forward * speedZ * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            Debug.Log("Bullet hit Player1");
            collision.GetComponent<Mov>().InvertControls();
        }
        else if (collision.CompareTag("Player2"))
        {
            Debug.Log("Bullet hit Player2");
            collision.GetComponent<Mov2>().InvertControls();
        }
    }
}