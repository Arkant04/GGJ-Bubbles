using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class blinkText : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI tutorialText;
    float duration = 5f;
    void Start()
    {
        StartCoroutine(BlinkText());
    }
    IEnumerator BlinkText()
    {
        float elapsedTime = 0;
        while (elapsedTime <= duration)
        {
            tutorialText.enabled = !tutorialText.enabled;
            yield return new WaitForSeconds(0.9f);
            elapsedTime += 0.5f;
            print(elapsedTime);
        }
        tutorialText.enabled = false;

    }
}
