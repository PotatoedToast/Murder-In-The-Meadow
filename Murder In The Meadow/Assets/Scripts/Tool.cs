using UnityEngine;

[CreateAssetMenu(fileName = "NewTool", menuName = "Game/Tool")]
public class Tool : ScriptableObject {
    public string toolName;
    public Sprite toolIcon;
}