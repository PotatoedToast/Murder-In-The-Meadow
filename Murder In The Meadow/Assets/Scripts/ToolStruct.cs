using UnityEngine;

[System.Serializable]

public class ToolStruct
{
    public string toolName;
    [TextArea(3, 5)]
    public string toolDescription; 
    public Sprite toolIcon;
    
}
