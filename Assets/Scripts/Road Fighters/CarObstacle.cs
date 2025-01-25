using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CarObstacle : MonoBehaviour
{
    BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collider.enabled = false;
            collision.GetComponent<MainChar>().AddPoint();
        }
    }

    public void EnableCar(Vector3 location)
    {
        transform.position = location;

        collider = GetComponent<BoxCollider2D>();
        collider.enabled = true;
        collider.isTrigger = true;
    }

    public void DisableCar(Vector3 poolLocation)
    {

    }
}
