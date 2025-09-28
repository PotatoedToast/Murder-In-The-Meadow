using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotebookToggle : MonoBehaviour {
    public GameObject notebookUI;
    public TMP_InputField userNotes;
    private bool on = false;
    public Button button;

    void Start() {
        notebookUI.SetActive(false);
    }

    public void toggle() {
        if (on) {
            CloseNotebook();
        } else {
            OpenNotebook();
        }
    }

    public void OpenNotebook() {
        notebookUI.SetActive(true);
        on = true;
    }

    public void CloseNotebook() {
        notebookUI.SetActive(false);
        on = false;
    }

}