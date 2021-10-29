using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [HideInInspector] public float horizontal = 0f;
    [HideInInspector] public float vertical = 0f;
    [HideInInspector] public float mouseX = 0f;
    [HideInInspector] public float mouseY = 0f;
    [HideInInspector] public float moveAmount = 0f;
    [HideInInspector] public bool lightAttack = false;
    [HideInInspector] public bool heavyAttack = false;
    [HideInInspector] public bool comboFlag = false;

    PlayerActions inputActions;
    PlayerAttacks playerAttacks;
    PlayerInventory inventory;
    PlayerManager playerManager;

    Vector2 movementInput;
    Vector2 cameraInput;

    private void Awake()
    {
        playerAttacks = GetComponent<PlayerAttacks>();
        inventory = GetComponent<PlayerInventory>();
        playerManager = GetComponent<PlayerManager>();
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
        {
            if(playerManager.canCombo)
            {
                comboFlag = true;
                playerAttacks.Combo(inventory.rightWeapon);
                comboFlag = false;
            }
            else
            {
                if (playerManager.canCombo || playerManager.isInteracting)
                    return;

                playerAttacks.HandleLightAttack(inventory.rightWeapon);
            }
        }

        if (heavyAttack)
            playerAttacks.HandleHeavyAttack(inventory.rightWeapon);
    }
}
