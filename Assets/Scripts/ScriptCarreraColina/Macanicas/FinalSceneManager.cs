using UnityEngine;
using TMPro;

public class FinalSceneManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI winnerText;

    void Start()
    {
        // Leer las puntuaciones de PlayerPrefs
        int scorePl1Bb = PlayerPrefs.GetInt("PuntosP1");
        int scorePl2Bb = PlayerPrefs.GetInt("PuntosP2", 0);

        // Determinar el ganador
        if (scorePl1Bb > scorePl2Bb)
        {
            winnerText.text = "Player 1 es el ganador!";
        }
        else if (scorePl1Bb < scorePl2Bb)
        {
            winnerText.text = "Player 2 es el ganador!";
        }
        else
        {
            winnerText.text = "¡Es un empate!";
        }
    }
}