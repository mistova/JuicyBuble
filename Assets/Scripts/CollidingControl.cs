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
            Push(collision.gameObject.transform);
        }
    }

    private void Push(Transform enemy)
    {
        StartCoroutine(ReverseForce(enemy));
    }

    IEnumerator ReverseForce(Transform enemy)
    {
        Vector3 distanceVector = (enemy.position - transform.position).normalized;
        Rigidbody rbEnemy = enemy.gameObject.GetComponent<Rigidbody>();
        rbEnemy.velocity = Vector3.zero;
        rbEnemy.AddForce(force * distanceVector * transform.lossyScale.x / enemy.lossyScale.x, ForceMode.Impulse);
        yield return new WaitForSeconds(forceTime);
        rbEnemy.AddForce(-force * distanceVector * transform.lossyScale.x / enemy.lossyScale.x, ForceMode.Impulse);
    }
}
