using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class CarObstacle : MonoBehaviour
{
    BoxCollider2D collider;
    Rigidbody2D rb;

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
            RoadFightersManager.instance.UpSpeed(collision.gameObject.GetComponent<MainChar>().playerIndex);
            RoadFightersManager.instance.MoveItemToPool(this, collision.gameObject.GetComponent<MainChar>().playerIndex);
        }
    }

    public void EnableCar(Vector3 location, float speed)
    {
        transform.position = location;

        rb.gravityScale = speed;
        rb.isKinematic = false;
        collider.enabled = true;
        collider.isTrigger = true;
    }

    public void DisableCar(Vector3 poolLocation)
    {
        transform.position = poolLocation;

        rb.isKinematic = true;
        rb.velocity = Vector3.zero;

        collider.enabled = false;
        collider.isTrigger = true;
    }
}
