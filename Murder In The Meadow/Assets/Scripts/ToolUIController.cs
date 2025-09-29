using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _toolName;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _toolIcon;
    private InputSystem_Actions _playerInputActions;

    public void ConfigureTools(string _name, string _message, Sprite _icon)
    {
        _toolName.text = _name;
        _description.text = _message;

        // 2. Set the Image (Sprite) field
        if (_toolIcon != null)
        {
            _toolIcon.sprite = _icon;
        }
    }
    
}
