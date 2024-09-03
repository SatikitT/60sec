using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject name;
    public Clock clockScript;

    void Awake()
    {
        Time.timeScale = 0; // Pause the game at the start
        playButton.SetActive(true); // Show the play button
        name.SetActive(true); // Show the play button
    }

    public void StartGame()
    {
        Time.timeScale = 1; // Resume the game
        playButton.SetActive(false); // Hide the play button
        name.SetActive(false); // Hide the play button
    }

    void Update()
    {
        if (clockScript.timeLeft <= 0)
        {
            // Reset the scene when time is up
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
