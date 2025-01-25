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
            Mov player1Mov = collision.GetComponent<Mov>();
            player1Mov.InvertControls();
            StartCoroutine(ResetControlsAfterDelay(player1Mov, 1.5f));
        }
        else if (collision.CompareTag("Player2"))
        {
            Debug.Log("Bullet hit Player2");
            Mov2 player2Mov = collision.GetComponent<Mov2>();
            player2Mov.InvertControls();
            StartCoroutine(ResetControlsAfterDelay(player2Mov, 1.5f));
        }
    }

    IEnumerator ResetControlsAfterDelay(Mov player1Mov, float delay)
    {
        yield return new WaitForSeconds(delay);
        player1Mov.ResetControls();
    }

    IEnumerator ResetControlsAfterDelay(Mov2 player2Mov, float delay)
    {
        yield return new WaitForSeconds(delay);
        player2Mov.ResetControls();
    }
}
