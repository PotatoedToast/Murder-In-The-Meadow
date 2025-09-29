using UnityEngine;

[CreateAssetMenu]
public class DialogueAsset : ScriptableObject
{
    [TextArea]
    new public string name;
    public string[] dialogue;

    
}
