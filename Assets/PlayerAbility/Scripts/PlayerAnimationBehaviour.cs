using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Reference to UnityChan animator controller")]
    public Animator playerAnimator;

    private int movementAnimationId;

    private void SetAnimationBehaviour()
    {
        movementAnimationId = Animator.StringToHash("Movement");
    }
    void Start()
    {
        SetAnimationBehaviour();   
    }

    public void PlayMovementAnimation(float movementValue)
    {
        playerAnimator.SetFloat(movementAnimationId, movementValue);
    }


}
