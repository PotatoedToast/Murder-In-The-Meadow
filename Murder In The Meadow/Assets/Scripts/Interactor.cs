using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; 


interface IInteractable{
    
    void Interact();

    void Close();

    void Highlight(bool isHighlighted);
}

public class Interactor : MonoBehaviour
{
    private InputSystem_Actions _playerInputActions;
    [SerializeField] private float interactRange;
    [SerializeField] private Transform InteractorSource;
    [SerializeField] private LayerMask interactableMask; 
    IInteractable _currentInteractable;


    void Awake()
    {
        _playerInputActions = new InputSystem_Actions();
        _playerInputActions.Player.Interact.started += Interact_Performed; 
        _playerInputActions.Player.Previous.started += closeWindow; 
        _currentInteractable = null;

     }

    private void OnEnable(){
        _playerInputActions.Player.Enable();
        interactRange = 1.5f;
    }

    private void OnDisable(){
        _playerInputActions.Player.Disable();
    }

    private void checkProxmity()
    {
        Vector3 origin = InteractorSource.position;
        IInteractable closestInteractable = null;

        Collider[] hitColliders = Physics.OverlapSphere(origin, interactRange, interactableMask);

        foreach (var hitCollider in hitColliders){
            if(hitCollider.gameObject.TryGetComponent(out IInteractable interactable)){
                closestInteractable = interactable;
                break; 
            }
        }

        if (closestInteractable != null && closestInteractable != _currentInteractable)
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.Highlight(false);
            }
            _currentInteractable = closestInteractable;
            _currentInteractable.Highlight(true);
        }
        else if (closestInteractable == null && _currentInteractable != null)
        {
            _currentInteractable.Highlight(false);
            _currentInteractable = null;
        }
    }

    private void Interact_Performed(InputAction.CallbackContext context){
        if (_currentInteractable != null)
        {
            _currentInteractable.Interact();
        }
    }

    private void closeWindow(InputAction.CallbackContext context){
        _currentInteractable.Close();
    }
        

    void Update()
    {
        checkProxmity();
    }

}
