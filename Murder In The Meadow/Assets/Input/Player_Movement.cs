using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

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
    }
    
    private void OnDisable(){
        _playerInputActions.Player.Disable();
    }

    private void Update(){ 
        getInput();
        Move();
        UpdateSprintDirection();
    }

    private void Move(){
        Vector3 moveDirection = _input * speed * Time.deltaTime;
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
        float horizontalMovement = _input.x;
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
