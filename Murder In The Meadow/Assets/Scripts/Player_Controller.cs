using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private InputSystem_Actions _playerInputActions;
    private Vector3 _input;
    private CharacterController _characterController;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite walkRightSprite; 
    [SerializeField] private Sprite walkLeftSprite;

    private void Awake(){
        //Initializes player input and character controller
        _playerInputActions = new InputSystem_Actions();
        _characterController = GetComponent<CharacterController>();
        _spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void OnEnable(){
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Tool.performed += UseTool; 
        _playerInputActions.Player.Previous.performed += UseTool; 

    }
    
    private void OnDisable(){
        _playerInputActions.Player.Disable();
        _playerInputActions.Player.Tool.performed -= UseTool;
        _playerInputActions.Player.Previous.performed += UseTool; 

    }

    private void Update(){ 
        getInput();
        Move();
        UpdateSprintDirection();
    }

    private void Move(){
        Vector3 moveDirection = _input * _speed * Time.deltaTime;
        _characterController.Move(moveDirection);
    }

    private void getInput(){
        Vector2 input = _playerInputActions.Player.Move.ReadValue<Vector2>();

        float angle = -45f * Mathf.Deg2Rad; // Note the negative sign for clockwise rotation

        Vector2 rawInput = input; // Assuming 'input' is the raw (x, y) vector
        float cosAngle = Mathf.Cos(angle);
        float sinAngle = Mathf.Sin(angle);

// Apply standard 2D rotation for movement mapping
        Vector2 isometricInput = new Vector2(
            rawInput.x * cosAngle - rawInput.y * sinAngle, // x' = x*cos(θ) - y*sin(θ)
            rawInput.x * sinAngle + rawInput.y * cosAngle  // y' = x*sin(θ) + y*cos(θ)
        );

// Map to 3D world vector (X-Z plane)
        _input = new Vector3(isometricInput.x, 0, isometricInput.y);
    }

    private void UpdateSprintDirection(){
        if(_speed != 0){
            float horizontalMovement = _input.x;
            if (horizontalMovement != 0)
                {
                if (horizontalMovement > 0) // Moving Screen-Right
                {
                    // Assign the sprite you want to use when the character walks right
                    _spriteRenderer.sprite = walkRightSprite;
                }
                else // Moving Screen-Left
                {
                    // Assign the sprite you want to use when the character walks left
                    _spriteRenderer.sprite = walkLeftSprite;
                }
            }
        }
        
    }

    public void setSpeed(int num){
        _speed = num;
    }

    private void UseTool(InputAction.CallbackContext context)
    {
        string controlPath = context.control.path;

        int toolIndex = -1; 
    
        switch (controlPath)
        {
            case "/Keyboard/q":
            case "/Keyboard/Q":
                GameManager.Instance._ToolController.HidePanel(); 
                return;
            case "/Keyboard/1":
                toolIndex = 0; // Index 0 for Tool 1
                break;
            case "/Keyboard/2":
                toolIndex = 1; // Index 1 for Tool 2
                break;
            case "/Keyboard/3":
                toolIndex = 2; // Index 2 for Tool 3
                break;
            case "/Keyboard/4":
                toolIndex = 3; // Index 3 for Tool 4
                break;
            default:
                return;
        }

        GameManager.Instance._ToolController.DisplayTool(toolIndex);

    }
}
