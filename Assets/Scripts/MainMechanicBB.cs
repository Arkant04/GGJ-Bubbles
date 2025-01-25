using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMechanicBB : MonoBehaviour
{
    float minScaleBB = 1.0f;
    float maxScaleBB = 10.0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            transform.localScale += Vector3.one;



        if (transform.localScale.magnitude >= maxScaleBB)
        {
            StartCoroutine(bbGoingSmall());
           // transform .localScale -= Vector3.one;
            print("ooooooooooooooo");
        }

        if (transform.localScale.magnitude <= minScaleBB)
        {
            transform.localScale = Vector3.one;
        }
    }
    IEnumerator bbGoingSmall()
    {
        while (transform.localScale.magnitude >= minScaleBB)
        {

            transform .localScale -= new Vector3(0.00001f, 0.00001f, 0.00001f);
            yield return null;

        }
        yield return 0;
    }
}