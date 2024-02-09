using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Player Behaviour")]
    public PlayerMovementBehaviour playerMovementBehaviour;
    public PlayerAnimationBehaviour playerAnimationBehaviour;

    private Vector3 rawMovementInput;
    private Vector3 smoothMovementInput;

    public float smoothingMovementSpeed = 1f;
    
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 movement = value.ReadValue<Vector2>();
        rawMovementInput = new Vector3(movement.x, 0f, movement.y);
    }

    private void SmoothingMovementInput()
    {
        smoothMovementInput = Vector3.Lerp(rawMovementInput, smoothMovementInput, smoothingMovementSpeed * Time.deltaTime);
    }

    private void UpdateMovement()
    {
        playerMovementBehaviour.UpdateMovementData(smoothMovementInput);
    }

    private void UpdatePlayerMovementAnimation()
    {
        playerAnimationBehaviour.PlayMovementAnimation(smoothMovementInput.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        SmoothingMovementInput();
        UpdateMovement();
        UpdatePlayerMovementAnimation();
    }
}
