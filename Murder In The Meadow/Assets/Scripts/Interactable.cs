using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour, IInteractable
{

    [SerializeField] private InteractWindowScript windowController;


    private Color _originalColor; 
    private Renderer _renderer;

    private void Awake(){
        _renderer = GetComponent<Renderer>();
        if (_renderer != null){
            _originalColor = _renderer.material.color;
        }
    }

    public void Interact(){
        if (windowController != null)
        {
            windowController.OpenWindow(); 
        }
        else
        {
            Debug.LogError("InteractWindowScript reference is missing on the Interactable object: " + gameObject.name);
        }
    }

    public void Close(){

        if (windowController != null){
            windowController.HideWindow();
        }
    }

    public void Highlight(bool isHighlighted){
        if (_renderer != null){
            if (isHighlighted){
                float tintAmount = 0.5f; // Adjust this value (0.0 to 1.0)
                _renderer.material.color = Color.Lerp(_originalColor, Color.white, tintAmount);
            } else {
                _renderer.material.color = _originalColor; // Default color
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}

