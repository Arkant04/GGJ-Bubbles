using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadFightersManager : MonoBehaviour
{
    [HideInInspector]
    public static RoadFightersManager instance;
    private bool isPlaying = true;

    [Header("Gameplay")]
    public float speedP1 = 0;
    public float speedP2 = 0;
    public float incrementSpeed = 0.1f;
    public float spawnInterval = 1f;

    [Header("Obstacles")]
    public float carSpeedP1 = 0;
    public float carSpeedP2 = 0;
    public float carSpeedIncrement = 0.1f;

    [Header("Backgrounds")]
    public Sprite[] Fondos;

    [Header("Item pool")]
    public List<CarObstacle> pool;

    public Transform poolLocation;

    public Transform[] carSpawnPointsP1;
    public Transform[] carSpawnPointsP2;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            //CarObstacle[] arrays
        }
    }

    void Start()
    {
        StartCoroutine(SpawnCar());
    }

    public void UpSpeed(int index)
    {
        switch (index)
        {
            case 1:
                speedP1 += incrementSpeed;
                carSpeedP1 += carSpeedIncrement;
                Debug.Log("Speed: " + speedP1);
                break;
            case 2:
                speedP2 += incrementSpeed;
                carSpeedP2 += carSpeedIncrement;
                Debug.Log("Speed: " + speedP1);
                break;
            default:
                break;
        }
    }

    public void MoveItemToPool(CarObstacle item, int playerIndex)
    {
        item.DisableCar(poolLocation.position);
        pool.Add(item);
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
                carSpeedP1 = 1;
                break;
            case 2:
                speedP2 = 1;
                carSpeedP2 = 1;
                break;
        }
    }

    private IEnumerator SpawnCar()
    {
        if (isPlaying)
        {
            if (speedP1 > 0)
            {
                Transform spawn = carSpawnPointsP1[Random.Range(0, carSpawnPointsP1.Length)];
                CarObstacle car = pool[0];
                pool.Remove(car);

                car.EnableCar(spawn.position, carSpeedP1);
                
            }

            if(speedP2 > 0)
            {
                Transform spawn = carSpawnPointsP2[Random.Range(0, carSpawnPointsP2.Length)];
                CarObstacle car = pool[0];
                pool.Remove(car);

                car.EnableCar(spawn.position, carSpeedP2);
            }
        }

        yield return new WaitForSeconds(spawnInterval);

        StartCoroutine(SpawnCar());
    }
}
