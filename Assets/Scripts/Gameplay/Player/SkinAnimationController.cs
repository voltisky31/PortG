using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAnimationController : MonoBehaviour
{
    Vector3 lastFramePosition;
    [SerializeField] Animator animator;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        if (ReferenceEquals(characterController, null))
            return;

        var dir = transform.InverseTransformDirection(characterController.velocity.normalized);
        animator.SetFloat("MovementX", dir.x);
        animator.SetFloat("MovementY", dir.z);
    }
}
