using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] private ToolUIController _toolPanel;
    [SerializeField] private GameObject _requiredCanvas; 

    public ToolStruct[] _tools;

    public void DisplayTool(int _toolNum)
    {
        if (_toolNum < 0 || _toolNum >= _tools.Length)
        {
            Debug.LogError("Tool index " + _toolNum + " is out of range. Check the size of the All Tools array.");
            return;
        }

        ToolStruct data = _tools[_toolNum];
        
        // Pass the data to the UI controller
        _toolPanel.ConfigureTools(data.toolName, data.toolDescription, data.toolIcon);
        
        // Ensure the panel is visible
        _toolPanel.gameObject.SetActive(true);
    }
    
    public void HidePanel()
    {
        _toolPanel.gameObject.SetActive(false);
    }

    void Update(){
        if(_requiredCanvas == null || !_requiredCanvas.activeInHierarchy)
        {
            HidePanel();
            return; 
        }
    }
    
}
