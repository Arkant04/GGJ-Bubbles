using System.Collections;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public float speed = 5.0f;
    private float screenLimitX = 8.5f;
    private bool controlsInverted = false;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 position = transform.position;

        if (controlsInverted)
        {
            if (Input.GetKey(KeyCode.A))
            {
                position.x += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                position.x -= speed * Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                position.x -= speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                position.x += speed * Time.deltaTime;
            }
        }

        position.x = Mathf.Clamp(position.x, -screenLimitX, screenLimitX);
        transform.position = position;
    }

    public void InvertControls()
    {
        StartCoroutine(InvertControlsCoroutine());
    }

    IEnumerator InvertControlsCoroutine()
    {
        controlsInverted = true;
        yield return new WaitForSeconds(2f);
        controlsInverted = false;
    }
    public void ResetControls()
    {
        controlsInverted = false;
    }
}