using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Incluye el espacio de nombres

public class BubbleBricks : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float limite;
    [SerializeField] List<GameObject> players; // Referencia a los jugadores
    int bricksHittedPl1;
    int BricksHittedPl2;
    bool isPlaying = true;
    [SerializeField] int bricksToWin = 1; // Número de bricks para ganar

    private ParticleSystem particle;
    private Vector3 direction = Vector3.right;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {

    }

    void Update()
    {
        //Debug.Log("bricksHittedPl1: " + bricksHittedPl1);
        //Debug.Log("BricksHittedPl2: " + BricksHittedPl2);

        transform.position += speed * Time.deltaTime * direction;

        if (transform.position.x >= limite)
        {
            direction = Vector3.left;
        }
        else if (transform.position.x <= -limite)
        {
            direction = Vector3.right;
        }

        if (isPlaying)
        {
            if (players != null && players.Count >= 2)
            {
                int scoreP1 = players[0].GetComponent<MainChar>().GetPoints();
                int scoreP2 = players[1].GetComponent<MainChar>().GetPoints();

                isPlaying = false;

                if (scoreP1 > scoreP2)
                {
                    PlayerPrefs.SetInt("PuntosP1", PlayerPrefs.GetInt("PuntosP1") + 1);
                }
                else if (scoreP1 < scoreP2)
                {
                    PlayerPrefs.SetInt("PuntosP2", PlayerPrefs.GetInt("PuntosP2") + 1);
                }
                else
                {
                    PlayerPrefs.SetInt("PuntosP1", PlayerPrefs.GetInt("PuntosP1") + 1);
                    PlayerPrefs.SetInt("PuntosP2", PlayerPrefs.GetInt("PuntosP2") + 1);
                }
            }
        }

        if (bricksHittedPl1 >= bricksToWin || BricksHittedPl2 >= bricksToWin)
        {
            print("fafsjgisjghis");
            ChangeScene();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.CompareTag("bullet1") && collision.CompareTag("Blue"))
        {
            bricksHittedPl1 ++;
            print("bricksHittedPl1: " + bricksHittedPl1);
            StartCoroutine(DeactivateAfterDelay());
        }
        else if (gameObject.CompareTag("bullet2") && collision.CompareTag("Red"))
        {
            BricksHittedPl2 ++;
            print("BricksHittedPl2: " + BricksHittedPl2);
            StartCoroutine(DeactivateAfterDelay());
        }
    }

    IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }

    void ChangeScene()
    {
       print("AÑAAAAAAA"); 
        SceneManager.LoadScene("RoadFighters");
    }
}