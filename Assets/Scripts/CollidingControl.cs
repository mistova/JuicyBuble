using System.Collections;
using UnityEngine;

public class CollidingControl : MonoBehaviour
{
    [SerializeField]
    string enemyTag = "Player";

    [SerializeField]
    float force = 10, forceTime = 0.75f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            collision.gameObject.GetComponent<CollidingControl>().Push(transform);
        }
    }

    internal void Push(Transform enemy)
    {
        StartCoroutine(PushAsync(enemy));
    }

    IEnumerator PushAsync(Transform enemy)
    {
        Vector3 distanceVector = (transform.position - enemy.position).normalized;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(force * distanceVector * enemy.lossyScale.x / transform.lossyScale.x, ForceMode.Impulse);
        yield return new WaitForSeconds(forceTime);
        rb.velocity = Vector3.zero;
    }
}
