using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    float scaleDownAmount = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<BallScale>().ChangeScale(scaleDownAmount);
        Destroy(this.gameObject);
    }
}
