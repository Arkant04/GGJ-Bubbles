using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class MainChar : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private int points = 0;
    private bool canEarnPoints = true;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boxCollider.enabled = false;
        //Invencibilidad
        canEarnPoints = false;

    }

    public void AddPoint()
    {
        points++;
    }


    #region Getters and Setters
    public int Getpoints()
    {
        return points;
    }

    private void Setpoints(int value)
    {
        points = value;
    }
    #endregion
}
