using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{

    public float timeRemaining;
    public bool timerIsRunning = false; 

    public TextMeshProUGUI timeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetTimerForScene();
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            } else {
                
                timeRemaining = 0;
                timerIsRunning = false;

                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
                    SceneManager.LoadScene(nextSceneIndex);
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay) {
        // switch scenes
        int minutes = Mathf.FloorToInt(timeToDisplay/60);
        int seconds = Mathf.FloorToInt(timeToDisplay%60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void SetTimerForScene() {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneIndex) {
            case 0:
                timeRemaining = 240f;
                break;
            case 1:
                timeRemaining = 180f;
                break;
            case 2:
                timeRemaining = 120f;
                break;
        }
    }
}
