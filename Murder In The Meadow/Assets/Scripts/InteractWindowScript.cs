using UnityEngine;

public class InteractWindowScript : MonoBehaviour
{
     
    [SerializeField] private GameObject _targetWindow;
    [SerializeField] private Player_Controller _player;
    private const float TOGGLE_INTERVAL = 5.0f; 



     public void OpenWindow(){
        if(_targetWindow != null && _player != null){
            _targetWindow.SetActive(true);
            _player.setSpeed(0);

        }
     }

     public void HideWindow(){
        if(_targetWindow != null){
            _targetWindow.SetActive(false);
            _player.setSpeed(3);
        }
     }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        HideWindow();
        
    }

}
