using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class WorldSwitchManager : MonoBehaviour
{
    public GameObject codePopup;
    public InputField codeInput;
    public Text feedbackText;
    public Text questionText;

    public string numericCode = "7419";
    public string choiceCode = "A";
    public string nextSceneName;

    private int currentSceneIndex;
    public string upColliderName;
    public string downColliderName;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // questionText.gameObject.SetActive(false);
        // codeInput.gameObject.SetActive(false);
        // feedbackText.text = "";
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     OpenPopup();
        // }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(currentSceneIndex);
        
        if (other.tag == "Player")
        {
            if (gameObject.name == upColliderName)
            {
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
            else if (gameObject.name == downColliderName)
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }

    void OpenPopup()
    {
        codePopup.SetActive(true);
        feedbackText.text = "";

        if (currentSceneIndex == 0)
        {
            questionText.gameObject.SetActive(false);
            codeInput.gameObject.SetActive(true);
            codeInput.text = "";
        }
        else if (currentSceneIndex == 1)
        {
            questionText.gameObject.SetActive(true);
            questionText.text = "What type of necklace is Bella wearing?\nA: Pearls\nB: Diamond\nC: Ruby";
            codeInput.gameObject.SetActive(true);
            codeInput.text = "";
        }

        codeInput.Select();
        codeInput.ActivateInputField();
    }

    public void Submit()
    {
        if (currentSceneIndex == 0)
        {
            if (codeInput.text == numericCode)
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                feedbackText.text = "Wrong code! Try again.";
            }
        }
        else if (currentSceneIndex == 1)
        {
            if (codeInput.text.ToUpper() == choiceCode)
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                feedbackText.text = "Wrong answer! Try again.";
            }
        }
    }

    public void ClosePopup()
    {
        codePopup.SetActive(false);
    }
}