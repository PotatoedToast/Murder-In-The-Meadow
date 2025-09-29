using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotebookToggle : MonoBehaviour {
    public GameObject notebookUI;
    public TMP_InputField userNotes;
    private bool on = false;
    public Button button;

    void Start() {
        PlayerPrefs.SetString("murder_notes", "Write any useful notes here.");
        notebookUI.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            toggle();
        }
    }

    public void toggle() {
        if (on) {
            CloseNotebook();
        } else {
            OpenNotebook();
        }
    }

    public void OpenNotebook() {
        userNotes.text = PlayerPrefs.GetString("murder_notes");
        notebookUI.SetActive(true);
        on = true;
    }

    public void CloseNotebook() {
        notebookUI.SetActive(false);
        PlayerPrefs.SetString("murder_notes", userNotes.text);
        on = false;

    }

}