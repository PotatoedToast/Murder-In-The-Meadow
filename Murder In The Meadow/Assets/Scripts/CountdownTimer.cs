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

                SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            }
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            switch (sceneIndex) {
                case 1:
                    PlayerPrefs.SetString("bedroom_time_remaining", System.Convert.ToString(timeRemaining));
                    break;
                case 2:
                    PlayerPrefs.SetString("tavern_time_remaining", System.Convert.ToString(timeRemaining));
                    break;
                case 3:
                    PlayerPrefs.SetString("basement_time_remaining", System.Convert.ToString(timeRemaining));
                    break;
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
                timeRemaining = (float) System.Convert.ToDouble(PlayerPrefs.GetString("bedroom_time_remaining"));
                break;
            case 2:
                timeRemaining = (float) System.Convert.ToDouble(PlayerPrefs.GetString("tavern_time_remaining"));
                break;
            case 3:
                timeRemaining = (float) System.Convert.ToDouble(PlayerPrefs.GetString("basement_time_remaining"));
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
