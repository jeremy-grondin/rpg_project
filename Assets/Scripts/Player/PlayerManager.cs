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
        CheckInteractable();
        isInteracting = anim.GetBool("IsInteracting");
        canCombo = anim.GetBool("CanCombo");

        if (!isInteracting)
            playerLocomotion.MoveAndRotate();
    }

    private void LateUpdate()
    {
        input.ResetInput();
    }

    public void CheckInteractable()
    {
        RaycastHit hit;
        
        if (Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 1f))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                
                if(interactable && input.interact)
                    interactable.Interact(this);
            }
        }
    }
}
