using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleInputsHandler : MonoBehaviour
{
    public static PuzzleInputsHandler Instance;
    [HideInInspector] public PuzzlePlayerInputs playerInputs;
    PuzzleMovement movement;

    private void Awake()
    {
        Instance = this;
        movement = GetComponent<PuzzleMovement>();
    }
    public void SetInputs(bool enable)
    {
        if (enable)
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerInputs.Movement.Enable();
            playerInputs.Movement.Interact.performed += Interact_performed;
            playerInputs.Movement.Run.performed += Run_performed;
            playerInputs.Movement.Run.canceled += Run_performed;
            playerInputs.Movement.Jump.performed += Jump_performed;
            playerInputs.Movement.Move.performed += Move_performed;
            playerInputs.Movement.Move.canceled += Move_performed;
        }
        else
        {
            playerInputs.Movement.Interact.performed -= Interact_performed;
            playerInputs.Movement.Run.performed -= Run_performed;
            playerInputs.Movement.Run.canceled -= Run_performed;
            playerInputs.Movement.Jump.performed -= Jump_performed;
            playerInputs.Movement.Move.performed -= Move_performed;
            playerInputs.Movement.Move.canceled -= Move_performed;
            playerInputs.Movement.Disable();
        }
    }
    private void Move_performed(InputAction.CallbackContext obj)
    {
        movement.horizontal = obj.ReadValue<Vector2>().x;
        movement.vertical = obj.ReadValue<Vector2>().y;
    }

    private void Run_performed(InputAction.CallbackContext obj)
    {
        if (obj.performed) movement.RunPerformed();
        if (obj.canceled) movement.RunCancled();
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (obj.performed) movement.JumpPerformed();
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        if (obj.performed) movement.InteractPerformed();
    }
    
    private void OnEnable()
    {
        playerInputs = new PuzzlePlayerInputs();
        SetInputs(true);
    }
    private void OnDisable()
    {
        SetInputs(false);
    }
}
