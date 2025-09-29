using UnityEngine;
using UnityEngine.UI;

public class Objects : MonoBehaviour
{

    [SerializeField] private string toolNeeded;
    [SerializeField] private DialogueAsset success;
    [SerializeField] private DialogueAsset failure;
    [SerializeField] private Sprite icon;
    
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
