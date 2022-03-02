using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator anim;
    InputHandler input;
    Interactable interactable;
    PlayerLocomotion playerLocomotion;
    
    [SerializeField] InteractableUI interactableUI;
 
    [HideInInspector] public bool isInteracting = false;

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
        //TODO enlever de l'update, utiliser les collisionsEnter et exit
        //CheckInteractable();
        isInteracting = anim.GetBool("IsInteracting");
        canCombo = anim.GetBool("CanCombo");

        if (!isInteracting)
            playerLocomotion.MoveAndRotate();
    }

    private void LateUpdate()
    {
        input.ResetInput();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            interactable = other.gameObject.GetComponent<Interactable>();
            interactableUI.interactableText.text = interactable.interactalbeText;
            interactableUI.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            if (interactable && input.interact)
            {
                interactable.Interact(this);
                interactableUI.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            interactableUI.gameObject.SetActive(false);
            interactable = null;
        }
    }
}
