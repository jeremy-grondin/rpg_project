using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : Interactable
{
    [SerializeField] private WeaponItem weapon;
    
    public override void Interact(PlayerManager playerManager) 
    {
        Debug.Log("Interact");
        PickUpItem(playerManager);
    }

    private void PickUpItem(PlayerManager playerManager)
    {
        PlayerInventory playerInventory = playerManager.GetComponent<PlayerInventory>();
        PlayerLocomotion playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
        AnimatorHandler anim = playerManager.GetComponentInChildren<AnimatorHandler>();

        playerLocomotion.rb.velocity = Vector3.zero;
        anim.PlayAnimation("PickUp", true);
        playerInventory.weapons.Add(weapon);
        Destroy(gameObject);
    }
}
