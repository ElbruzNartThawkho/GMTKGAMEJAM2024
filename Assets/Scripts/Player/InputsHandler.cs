using UnityEngine;
using UnityEngine.InputSystem;


public class InputsHandler : MonoBehaviour
{
    [HideInInspector] public PlayerInputs playerInputs;
    Movement movement;
    WeaponManager weaponManager;
    private void Awake()
    {
        movement = GetComponent<Movement>();
        weaponManager = GetComponent<WeaponManager>();
    }
    public void SetInputs(bool enable)
    {
        if (enable)
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerInputs.Movement.Enable();
            playerInputs.Movement.Run.performed += Run_performed;
            playerInputs.Movement.Run.canceled += Run_performed;
            playerInputs.Movement.Jump.performed += Jump_performed;
            playerInputs.Movement.Crouch.performed += Crouch_performed;
            playerInputs.Movement.Move.performed += Move_performed;
            playerInputs.Movement.Move.canceled += Move_performed;
            playerInputs.Movement.Shoot.performed += Shoot_performed;
            playerInputs.Movement.ChangeWeapon.performed += ChangeWeapon_performed;
        }
        else
        {
            playerInputs.Movement.Jump.performed -= Jump_performed;
            playerInputs.Movement.Run.performed -= Run_performed;
            playerInputs.Movement.Run.canceled -= Run_performed;
            playerInputs.Movement.Crouch.canceled -= Crouch_performed;
            playerInputs.Movement.Move.performed -= Move_performed;
            playerInputs.Movement.Move.canceled -= Move_performed;
            playerInputs.Movement.Shoot.performed -= Shoot_performed;
            playerInputs.Movement.ChangeWeapon.performed -= ChangeWeapon_performed;
            playerInputs.Movement.Disable();
        }
    }

    private void ChangeWeapon_performed(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            weaponManager.ChangeWeapon((int)obj.ReadValue<float>());
        }
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            weaponManager.Shoot();
        }
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        movement.horizontal = obj.ReadValue<Vector2>().x;
        movement.vertical = obj.ReadValue<Vector2>().y;
    }

    private void Crouch_performed(InputAction.CallbackContext obj)
    {
        if(obj.performed) movement.SlidePerformed();
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (obj.performed) movement.JumpPerformed();
    }

    private void Run_performed(InputAction.CallbackContext obj)
    {
        if (obj.performed) movement.RunPerformed();
        if (obj.canceled) movement.RunCancled();
    }

    private void OnEnable()
    {
        playerInputs = new PlayerInputs();
        SetInputs(true);
    }
    private void OnDisable()
    {
        SetInputs(false);
    }
}
