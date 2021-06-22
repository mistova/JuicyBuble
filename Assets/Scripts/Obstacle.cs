using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    float scaleDownAmount= -0.5f;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<BallScale>().ChangeScale(scaleDownAmount);
        Destroy(this.gameObject);
    }
}
