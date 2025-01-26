using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // Resetear las puntuaciones en PlayerPrefs al iniciar el juego
        ResetScores();

        // Inicializar las puntuaciones desde PlayerPrefs
        scorePl1Bb = PlayerPrefs.GetInt("PuntosP1", 0);
        scorePl2Bb = PlayerPrefs.GetInt("PuntosP2", 0);

        // Mostrar las puntuaciones iniciales en la interfaz de usuario
        scoreTextPlBb1.text = scorePl1Bb.ToString();
        scoreTextPlBb2.text = scorePl2Bb.ToString();
    }

    void Update()
    {
        if (hasAnyPlayerWon)
            return;

        if (pl1Bb.localScale.magnitude <= 0)
        {
            scorePl1Bb += 1;
            scoreTextPlBb1.text = scorePl1Bb.ToString();
            PlayerPrefs.SetInt("PuntosP1", scorePl1Bb);
            hasAnyPlayerWon = true;
            ChangeScene();
        }

        if (pl2Bb.localScale.magnitude <= 0)
        {
            scorePl2Bb += 1;
            scoreTextPlBb2.text = scorePl2Bb.ToString();
            PlayerPrefs.SetInt("PuntosP2", scorePl2Bb);
            hasAnyPlayerWon = true;
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ResetScores()
    {
        PlayerPrefs.SetInt("PuntosP1", 0);
        PlayerPrefs.SetInt("PuntosP2", 0);
        PlayerPrefs.Save();
    }
}