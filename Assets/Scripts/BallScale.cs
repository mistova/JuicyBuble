using System.Collections;
using UnityEngine;

public class BallScale : MonoBehaviour
{
    [SerializeField]
    float ballBelowLimit = 1, ballUpLimit = 2, ballScaleChangeTime = 0.2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeScale(0.2f);

        if (Input.GetKeyDown(KeyCode.Backspace))
            ChangeScale(-0.2f);
    }

    internal void ChangeScale(float scale)
    {
        StartCoroutine(ChangeScaleAsync(scale));
    }

    IEnumerator ChangeScaleAsync(float scale)
    {
        int count = 20;
        float ballScale = transform.localScale.x;//Will be fixed.
        for (float i = 0; i < count; i++)
        {
            ballScale += scale / count;

            if (ballScale < ballBelowLimit)
                DestroyBall();
            else if (ballScale > ballUpLimit)
                ballScale = ballUpLimit;

            transform.localScale = Vector3.one * ballScale;

            yield return new WaitForSeconds(ballScaleChangeTime / count);
        }
    }

    void DestroyBall()
    {
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
