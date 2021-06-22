using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    Vector3 distance;
    void Start()
    {
        distance = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        transform.position = playerTransform.position + distance;
    }
}
