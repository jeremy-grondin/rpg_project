using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler input;
    PlayerLocomotion playerLocomotion;
    Animator anim;
    UIManager uiManager;
    PlayerStats playerStats;

    [SerializeField] private int healAmount = 5;
    [SerializeField] private GameObject particlesHeal;
 
    [HideInInspector]
    public bool isInteracting = false;

    [HideInInspector] public bool canCombo = false;

    private void Start()
    {
        input = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        uiManager = FindObjectOfType<UIManager>();
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        input.UpdateInput();
        isInteracting = anim.GetBool("IsInteracting");
        canCombo = anim.GetBool("CanCombo");

        if (input.inventoryFlag)
            return;

        if (!isInteracting)
            playerLocomotion.MoveAndRotate();

        if (input.heal)
            Heal();
    }

    private void LateUpdate()
    {
        input.lightAttack = false;
        input.heavyAttack = false;
        input.switchWeapon = false;
        input.inventoryInput = false;
        input.heal = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                uiManager.interactableText.text = interactable.interactableText;
                uiManager.interactablePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Interactable interactable = other.GetComponent<Interactable>();

            if (interactable != null && input.interact)
            {
                Debug.Log("Interact with weapon");
                interactable.Interact(this);
                input.interact = false;
                uiManager.interactablePanel.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                uiManager.interactableText.text = interactable.interactableText;
                uiManager.interactablePanel.SetActive(false);
            }
        }
    }

    private void Heal()
    {
        playerStats.Heal(healAmount);
        Instantiate(particlesHeal, transform);
    }
}
