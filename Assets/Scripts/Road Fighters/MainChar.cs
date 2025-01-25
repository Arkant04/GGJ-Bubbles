using System.Collections;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class MainChar : MonoBehaviour
{
    [Header("Player Index")]
    public int playerIndex = 1;

    private BoxCollider2D boxCollider;
    private int points = 0;
    private bool canEarnPoints = true;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.root.tag.Equals("Car"))
        {
            Debug.Log("Colisión detectada con objeto");
            StartCoroutine("Invencibility");
        }
    }

    public void AddPoint()
    {
        if (canEarnPoints)
        {
            points++;
        }
    }

    IEnumerator Invencibility()
    {
        canEarnPoints = false;
        RoadFightersManager.instance.Crash(playerIndex);

        yield return new WaitForSeconds(2);

        canEarnPoints=true;
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
