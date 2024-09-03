using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public float timeLeft = 60f;
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (Time.timeScale == 1)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time Left: " + Mathf.Round(timeLeft).ToString();

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                // Game Over logic here
                Debug.Log("Game Over!");
            }
        }
    }

    public void ReduceTime(float amount)
    {
        timeLeft -= amount;
    }
}
