using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public float horizontal = 0f;
    public float vertical = 0f;
    public float mouseX = 0f;
    public float mouseY = 0f;
    public float moveAmount = 0f;
    public bool lightAttack = false;
    public bool heavyAttack = false;

    PlayerActions inputActions;
    PlayerAttacks playerAttacks;
    PlayerInventory inventory;

    Vector2 movementInput;
    Vector2 cameraInput;

    private void Awake()
    {
        playerAttacks = GetComponent<PlayerAttacks>();
        inventory = GetComponent<PlayerInventory>();
    }

    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerActions();
            inputActions.PlayerControls.Move.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerControls.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void UpdateInput()
    {
        MoveInput();
        AttackInput();
    }

    private void MoveInput()
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    private void AttackInput()
    {
        inputActions.PlayerControls.LightAttack.performed += i => lightAttack = true;
        inputActions.PlayerControls.HeavyAttack.performed += i => heavyAttack = true;

        if (lightAttack)
            playerAttacks.HandleLightAttack(inventory.rightWeapon);

        if (heavyAttack)
            playerAttacks.HandleHeavyAttack(inventory.rightWeapon);
    }
}
