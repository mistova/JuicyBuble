using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed, moveDistance;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 distance = player.position - transform.position;

        if (distance.magnitude < moveDistance)
            Move(distance);
    }

    void Move(Vector3 distance)
    {
        transform.position += speed * Time.deltaTime * distance.normalized;
    }
}
