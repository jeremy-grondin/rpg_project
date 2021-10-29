using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler input;
    PlayerLocomotion playerLocomotion;
    Animator anim;
 
    [HideInInspector]
    public bool isInteracting = false;

    [HideInInspector] public bool canCombo = false;

    private void Start()
    {
        input = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        input.UpdateInput();
        isInteracting = anim.GetBool("IsInteracting");
        canCombo = anim.GetBool("CanCombo");

        if (!isInteracting)
            playerLocomotion.MoveAndRotate();
    }

    private void LateUpdate()
    {
        input.lightAttack = false;
        input.heavyAttack = false;
        input.switchWeapon = false;
    }
}
