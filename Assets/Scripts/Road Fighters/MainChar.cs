using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class MainChar : MonoBehaviour
{
    [Header("Player Index")]
    public int playerIndex = 1;
    [Header("Score")]
    public TextMeshProUGUI scoreText;
    private int points = 0;
    [Header("Inputs")]
    public KeyCode leftMove;
    public KeyCode rightMove;
    public float speed = 250;


    private BoxCollider2D boxCollider;
    private bool canEarnPoints = true;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.root.tag.Equals("Car"))
        {
            StartCoroutine(Invencibility(collision.transform.root.gameObject.GetComponent<CarObstacle>()));
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(leftMove))
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }

        if (Input.GetKey(rightMove))
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
    }

    public void AddPoint()
    {
        points++;
        scoreText.SetText("" + points * 10);
    }

    IEnumerator Invencibility(CarObstacle car)
    {
        RoadFightersManager.instance.Crash(playerIndex, car);

        yield return new WaitForSeconds(2);
    }


    #region Getters and Setters
    public int GetPoints()
    {
        return points;
    }

    private void SetPoints(int value)
    {
        points = value;
    }
    #endregion
}