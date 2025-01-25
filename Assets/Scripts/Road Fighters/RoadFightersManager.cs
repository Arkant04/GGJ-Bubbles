using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class RoadFightersManager : MonoBehaviour
{
    [HideInInspector]
    public static RoadFightersManager instance;
    private bool isPlaying = true;

    [Header("Gameplay")]
    public float speedP1 = 1;
    public float speedP2 = 1;
    public float incrementSpeed = 0.1f;
    public float spawnInterval = 5f;

    [Header("Obstacles")]
    public float carSpeedP1 = 0.25f;
    public float carSpeedP2 = 0.25f;
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

            GameObject[] aux = GameObject.FindGameObjectsWithTag("Car");
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i].transform.position = poolLocation.position;
                pool.Add(aux[i].GetComponent<CarObstacle>());
            }
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



    public void Crash(int index, CarObstacle car)
    {
        switch (index)
        {
            case 1:
                speedP1 = 0;
                carSpeedP1 = 0;
                car.DisableCar(poolLocation.position);
                pool.Add(car);
                StartCoroutine(RecoverTime(index));
                break;
            case 2:
                speedP2 = 0;
                carSpeedP2 = 0;
                StartCoroutine(RecoverTime(index));
                car.DisableCar(poolLocation.position);
                pool.Add(car);
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
                carSpeedP1 = 0.25f;
                break;
            case 2:
                speedP2 = 1;
                carSpeedP2 = 0.25f;
                break;
        }
    }

    private IEnumerator SpawnCar()
    {
        if (isPlaying)
        {
            if (speedP1 > 0)
            {
                Transform spawn1 = carSpawnPointsP1[Random.Range(0, carSpawnPointsP1.Length)];
                CarObstacle car1 = pool[0];

                car1.EnableCar(spawn1.position, carSpeedP1);
                pool.Remove(car1);
            }

            yield return new WaitForEndOfFrame();

            if(speedP2 > 0)
            {
                Transform spawn2 = carSpawnPointsP2[Random.Range(0, carSpawnPointsP2.Length)];
                CarObstacle car2 = pool[0];

                car2.EnableCar(spawn2.position, carSpeedP2);
                pool.Remove(car2);
            }

            yield return new WaitForSeconds(spawnInterval);

            StartCoroutine(SpawnCar());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Car"))
        {
            collision.GetComponent<CarObstacle>().DisableCar(poolLocation.position);
            pool.Add(collision.GetComponent<CarObstacle>());
        }
    }
}
