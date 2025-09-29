using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{

    public float timeRemaining;
    public bool timerIsRunning = false; 
    public DialogueAsset timeout;

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
                if (timeRemaining < 30 && timeRemaining > 29.5) {
                    DialogueController.Instance.StartDialogue(timeout.dialogue, timeout.name);
                }
            } else {
                
                timeRemaining = 0;
                timerIsRunning = false;

                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
                    SceneManager.LoadScene(nextSceneIndex);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) UseTool(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) UseTool(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseTool(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) UseTool(4);
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
            case 1:
                timeRemaining = 240f;
                break;
            case 2:
                timeRemaining = 180f;
                break;
            case 3:
                timeRemaining = 120f;
                break;
        }
    }

    void UseTool(int toolNumber) {
        switch (toolNumber) {
            case 1: 
                ReduceTime(15f);
                break;
            case 2:
                ReduceTime(10f);
                break;
            case 3:
                break;
            case 4: 
                break;
        }
    }

    void ReduceTime(float seconds) {
        timeRemaining -= seconds;
        if(timeRemaining < 0) {
            timeRemaining = 0;
        }
    }
}
