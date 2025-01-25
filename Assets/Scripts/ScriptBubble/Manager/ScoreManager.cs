using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Players Transform")]
    [SerializeField] Transform pl1Bb;
    [SerializeField] Transform pl2Bb;

    [Header("Scales min and max")]
    float minScaleBB = 1.0f;
    float midScaleBB = 2.0f;
    float maxScaleBB = 10.0f;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreTextPlBb1;
    [SerializeField] TextMeshProUGUI scoreTextPlBb2;
    int scorePl1Bb;
    int scorePl2Bb;


    bool hasAnyPlayerWon = false;
    void Start()
    {
        
    }

    void Update()
    {

        if(hasAnyPlayerWon)
            return;


        if (pl1Bb.localScale.magnitude <= 0)
        {
            scorePl1Bb += 1;
            scoreTextPlBb1.text = scorePl1Bb.ToString();
            hasAnyPlayerWon = true;
        }

        if (pl2Bb.localScale.magnitude <= 0)
        {
            scorePl2Bb += 1;
            scoreTextPlBb2.text = scorePl2Bb.ToString();
            hasAnyPlayerWon = true;
        }



    }
}
