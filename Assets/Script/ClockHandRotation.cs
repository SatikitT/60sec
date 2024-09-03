using UnityEngine;

public class ClockHandRotation : MonoBehaviour
{
    public Clock clockScript;
    public float maxTime = 60f;

    void Update()
    {
        RotateClockHand();
    }

    void RotateClockHand()
    {
        if (clockScript != null)
        {
            float timeLeft = clockScript.timeLeft;
            float rotationAngle = (timeLeft / maxTime) * 360f;
            transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        }
    }
}
