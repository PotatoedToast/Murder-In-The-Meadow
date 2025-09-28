using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour {
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject dialoguePanel;

    public string[] currDialogues;
    public string currName;
    public int i = 0;

    public static DialogueController Instance;

    void Start() {
        Instance = this;
        string[] d = {"Hello, my name is Derry the Platypus! Welcome to Murder in the Meadow.", 
                        "To move, press WASD. To interact, press [E]. Go ahead and explore the room."};
        string n = "Derry the Platypus";
        StartDialogue(d, n);
    }

    void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Space)) {
            NextDialogue();
        }
    }

    public void StartDialogue(string[] dialogues, string speaker) {
        currDialogues = dialogues;
        currName = speaker;
        i = 0;
        dialoguePanel.SetActive(true);
        ShowDialogue(currDialogues[i], currName);
        i++;
    }

    public void NextDialogue() {
        if (i < currDialogues.Length) {
            ShowDialogue(currDialogues[i], currName);
            i++;
        } else {
            EndDialogue();
        }
    }

    public void ShowDialogue(string dialogue, string name)
    {
        nameText.text = name + ":";
        dialogueText.text = dialogue;
    }

    public void EndDialogue()
    {
        nameText.text = "";
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }
}