using System.Collections;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    float lastFrameFingerPositionX;
    float moveFactorX;

    bool onClick = false;

    [SerializeField]
    float swerveSpeed = 0.5f, maxSwerveAmount = 1f, sideLimit = 1,  forwardSpeed = 10f;

    [SerializeField]
    float ballBelowLimit = 1, ballUpLimit = 2, ballUpMultiplier = 1, ballScaleChangeTime = 0.2f;

    void Update()
    {
        CalculateSwerveAmount();

        if (onClick)
            MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
            ChangeScale(0.2f);

        if (Input.GetKeyDown(KeyCode.Backspace))
            ChangeScale(-0.2f);
    }


    private void CalculateSwerveAmount()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
            onClick = true;
        }

        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0;
            onClick = false;
        }
    }

    void MovePlayer()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * moveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        if (transform.position.x < -sideLimit)
        {
            transform.position = new Vector3(- sideLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x > sideLimit)
        {
            transform.position = new Vector3(sideLimit, transform.position.y, transform.position.z);
        }
        Vector3 vec = new Vector3(swerveAmount, 0, forwardSpeed * Time.deltaTime);
        transform.Translate(vec);
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
    }
}
