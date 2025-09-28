using UnityEngine;

public class InteractWindowScript : MonoBehaviour
{
     
    [SerializeField] private GameObject _targetWindow;
    private const float TOGGLE_INTERVAL = 5.0f; 



     public void OpenWindow(){
        if(_targetWindow != null){
            _targetWindow.SetActive(true);
        }
     }

     public void HideWindow(){
        if(_targetWindow != null){
            _targetWindow.SetActive(false);
        }
     }

     public void ToggleWindow(){
        if(_targetWindow != null){
            _targetWindow.SetActive(!_targetWindow.activeSelf);
        }
     }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        HideWindow();
        
    }

}
