using System.Collections;
using UnityEngine;

public class RoadFightersManager : MonoBehaviour
{
    [HideInInspector]
    public static RoadFightersManager instance;

    [Header("Gameplay")]
    public static float speedP1 = 0;
    public static float speedP2 = 0;
    public static float incrementSpeed = 0.1f;

    [Header("Obstacles")]
    public static float carSpeedP1 = 0;
    public static float carSpeedP2 = 0;
    public static float carSpeedIncrement = 0.1f;

    [Header("Backgrounds")]
    public Sprite[] Fondos;

    [Header("Item pool")]
    public CarObstacle[] carP1Pool;
    public CarObstacle[] carP2Pool;
    public Transform poolLocation;
    public Transform[] carSpawnPoints;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        //Intro
        //StartCoroutine("ParallaxControl");
    }
    private void FixedUpdate()
    {
        if (speedP1 > 0)
        {
            //Mover imagen mas rápido
            //Mover coches mas rapido
            speedP1 += incrementSpeed * Time.deltaTime;
            carSpeedP1 += carSpeedIncrement * Time.deltaTime;
            Debug.Log("Speed: " + speedP1);
        }

        if (speedP2 > 0)
        {
            //Mover imagen mas rápido
            //Mover coches mas rapido
            speedP2 += incrementSpeed * Time.deltaTime;
            carSpeedP2 += carSpeedIncrement * Time.deltaTime;
            Debug.Log("Speed: " + speedP1);
        }
    }

    private void MoveItemToPool(CarObstacle item)
    {
        item.DisableCar(poolLocation.position);
    }



    public void Crash(int index)
    {
        switch (index)
        {
            case 1:
                speedP1 = 0;
                carSpeedP1 = 0;
                StartCoroutine(RecoverTime(index));
                break;
            case 2:
                speedP2 = 0;
                carSpeedP2 = 0;
                break;
            default:
                break;
        }


    }

    private IEnumerator RecoverTime(int PlayerCrashed)
    {
        yield return new WaitForSeconds(2);

        switch (PlayerCrashed)
        {
            case 1:
                speedP1 = 1;
                break;
            case 2:
                speedP2 = 1;
                break;
        }
    }

}
