using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{

    public Rigidbody playerRb;

    private Vector3 movementDirection;
    public float movementSpeed = 3f;
    public float turnSpeed = 1f;

    public Camera gameplayCamera;
    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    private void MovePlayer()
    {
        Vector3 movement = GetCameraTransform(movementDirection) * movementSpeed * Time.deltaTime;
        playerRb.MovePosition(this.transform.position + movement);
    }

    private void TurnPlayer()
    {
        if(movementDirection.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(GetCameraTransform(movementDirection));
            Quaternion rotation = Quaternion.Slerp(playerRb.rotation, targetRotation, turnSpeed);
                
            playerRb.MoveRotation(rotation);
        }
    }

    private Vector3 GetCameraTransform(Vector3 movement)
    {
        Vector3 cameraForward = gameplayCamera.transform.forward;
        Vector3 cameraRight = gameplayCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        return cameraForward * movement.z + cameraRight * movement.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        TurnPlayer();
    }
}
