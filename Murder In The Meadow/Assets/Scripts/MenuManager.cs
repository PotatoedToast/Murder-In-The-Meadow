using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    void Start() {
        PlayerPrefs.SetString("bedroom_time_remaining", "240");
        PlayerPrefs.SetString("tavern_time_remaining", "180");
        PlayerPrefs.SetString("basement_time_remaining", "120");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart(){
        SceneManager.LoadScene(0);
    }
}
