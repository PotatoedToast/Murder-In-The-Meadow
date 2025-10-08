using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotebookToggle : MonoBehaviour
{
    public GameObject notebookUI;
    public TMP_InputField userNotes;
    private bool on = false;
    public Button button;

    void Start()
    {
        if (!PlayerPrefs.HasKey("murder_notes"))
        {
            PlayerPrefs.SetString("murder_notes", "Write any useful notes here.");
        }

        notebookUI.SetActive(false);

        if (button != null)
        {
            button.onClick.AddListener(toggle);
        }
        userNotes.onSelect.AddListener(ClearDefaultText);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            toggle();
        }
    }

    public void toggle()
    {
        if (on)
        {
            CloseNotebook();
        }
        else
        {
            OpenNotebook();
        }
    }

    public void OpenNotebook()
    {
        userNotes.text = PlayerPrefs.GetString("murder_notes");
        notebookUI.SetActive(true);
        on = true;
    }

    public void CloseNotebook()
    {
        if (string.IsNullOrWhiteSpace(userNotes.text))
        {
            PlayerPrefs.SetString("murder_notes", "Write any useful notes here.");
        }
        else
        {
            PlayerPrefs.SetString("murder_notes", userNotes.text);
        }

        notebookUI.SetActive(false);
        on = false;
    }

    private void ClearDefaultText(string text)
    {
        if (text == "Write any useful notes here.")
        {
            userNotes.text = "";
        }
    }

}