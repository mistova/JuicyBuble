using System.Collections;
using UnityEngine;

public class BallScale : MonoBehaviour
{
    [SerializeField]
    float belowLimit = 1, upLimit = 2, scaleChangeTime = 0.2f;

    float ballScale;

    private void Start()
    {
        ballScale = transform.localScale.x;
    }

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
        for (float i = 0; i < count; i++)
        {
            ballScale += scale / count;

            if (ballScale < belowLimit)
                DestroyBall();
            else if (ballScale > upLimit)
                ballScale = upLimit;

            transform.localScale = Vector3.one * ballScale;

            yield return new WaitForSeconds(scaleChangeTime / count);
        }
    }

    void DestroyBall()
    {
        Destroy(this.gameObject);
    }
}
