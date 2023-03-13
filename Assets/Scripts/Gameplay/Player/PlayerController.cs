using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private FloatVariable HealthVariable;
    [SerializeField] private FloatVariable ManaVariable;
    [SerializeField] private FloatVariable StaminaVariable;

    private CharacterController characterController;

    [Header("Movmeent Settings")]
    [SerializeField] private float velocity = 5;
    [SerializeField] private float sprintModificator = 3;
    [SerializeField] private float staminaUse = 0.5f;
    [SerializeField] private LayerMask layerMask;

    [Header("Skill Settings")]
    [SerializeField] SkillSO JumpSkill;
    [SerializeField] SkillSO SprintSkill;

    private float yMovement = -9.81f;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There is more than one instance of this!", gameObject);
        
        Instance = this;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var movementValue = new Vector2(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"));

        if (SprintSkill.IsActive && Input.GetKey(KeyCode.LeftShift) && StaminaVariable.Value > 0)
        {
            movementValue *= sprintModificator;
            StaminaVariable.Value -= staminaUse * Time.deltaTime;
        }
        else
        {
            StaminaVariable.Value += Time.fixedDeltaTime;
            StaminaVariable.Value = Mathf.Clamp01(StaminaVariable.Value);
        }

        movementValue *= velocity;
        movementValue *= Time.deltaTime;

        characterController.Move(new Vector3(movementValue.x, yMovement * Time.deltaTime, movementValue.y));
        if(characterController.velocity.sqrMagnitude > 0.1)
            transform.forward = new Vector3(movementValue.x, 0f, movementValue.y);

        if (JumpSkill.IsActive && Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            yMovement = 10f;

        yMovement = Mathf.Max(-9.81f, yMovement - Time.deltaTime * 30f);
    }
}
