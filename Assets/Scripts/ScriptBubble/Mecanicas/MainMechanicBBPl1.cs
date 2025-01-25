using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMechanicBBPl1 : MonoBehaviour
{
    [SerializeField] Transform pl2Bb;
    [SerializeField] ParticleSystem ps;
    float minScaleBB = 1.0f;
    float midScaleBB = 2.0f;
    float maxScaleBB = 10.0f;
    bool isControlDisabled = false;
    void Start()
    {
        ps.Stop();
    }

    void Update()
    {
        if (isControlDisabled)
            return;


        if (Input.GetKeyDown(KeyCode.LeftControl) && transform.localScale.magnitude <= maxScaleBB)
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        //if(Input.GetKeyDown(KeyCode.RightControl))
        //    pl2Bb.localScale += Vector3.one;

        if (transform.localScale.magnitude >= midScaleBB)
        {
            StartCoroutine(bbGoingSmall());
            print("ooooooooooooooo");
        }

        if (transform.localScale.magnitude <= minScaleBB)
        {
            StopAllCoroutines();
            transform.localScale = Vector3.one;
        }

        if (transform.localScale.magnitude >= maxScaleBB)
        {
            StopAllCoroutines();
            transform.localScale = Vector3.zero;
            ps.Play();
            isControlDisabled = true;
        }

        if (pl2Bb.localScale.magnitude <= 0)
            isControlDisabled = true;

    }
    IEnumerator bbGoingSmall()
    {
        while (transform.localScale.magnitude >= minScaleBB)
        {

            transform.localScale -= new Vector3(0.000001f, 0.000001f, 0.000001f);
            //pl2Bb.localScale -= new Vector3(0.00001f, 0.00001f, 0.00001f);
            yield return null;

        }
        yield return 0;
    }
}