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
    [HideInInspector] public bool switchWeapon = false;
    [HideInInspector] public bool interact = false;

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
        SwitchWeaponInput();
        InteractInput();
    }

    public void ResetInput()
    {
        lightAttack = false;
        heavyAttack = false;
        switchWeapon = false;
        interact = false;
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
        
        //TODO refractorer ces 2 if
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
        {
            if (playerManager.canCombo)
            {
                comboFlag = true;
                playerAttacks.ComboHeavyAttack(inventory.rightWeapon);
                comboFlag = false;
            }
            else
            {
                if (playerManager.canCombo || playerManager.isInteracting)
                    return;

                playerAttacks.HandleHeavyAttack(inventory.rightWeapon);
            }
        }
    }

    private void SwitchWeaponInput()
    {
        inputActions.PlayerControls.NextWeapon.performed += i => switchWeapon = true;
        if(switchWeapon)
            inventory.ChangeWeaponRightHand();
    }

    private void InteractInput()
    {
        inputActions.PlayerControls.Interact.performed += i => interact = true;
    }
}
