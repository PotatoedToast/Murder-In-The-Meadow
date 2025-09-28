using UnityEngine;

public class Objects : MonoBehaviour
{

    public string toolNeeded;
    public bool canInteract = false;
    public DialogueAsset success;
    public DialogueAsset failure;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Investigate(Tool tool) {
        if (tool != null && tool.toolName == toolNeeded) {
            DialogueController.Instance.StartDialogue(success.dialogue, success.name);
        } else {
            DialogueController.Instance.StartDialogue(failure.dialogue, failure.name);
        }
    }

}
