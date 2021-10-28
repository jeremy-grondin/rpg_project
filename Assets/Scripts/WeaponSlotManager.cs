 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    DamageCollider leftHandDamageCollider;
    DamageCollider rightHandDamageCollider;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();

        foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHandSlot)
                leftHandSlot = weaponSlot;
            else
                rightHandSlot = weaponSlot;
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weapon, bool isLeft)
    {
        if (isLeft)
        {
            leftHandSlot.LoadWeaponModel(weapon);
            LoadLeftHandDamageCollider();
        }
        else
        {
            rightHandSlot.LoadWeaponModel(weapon);
            LoadRightHandDamageCollider();
        }
    }

    #region Weapon damage collider

    private void LoadLeftHandDamageCollider()
    {
        leftHandDamageCollider = leftHandSlot.GetComponentInChildren<DamageCollider>();
    }

    private void LoadRightHandDamageCollider()
    {
        rightHandDamageCollider = rightHandSlot.GetComponentInChildren<DamageCollider>();
    }

    public void EnableRightDamageCollider()
    {
        rightHandDamageCollider.EnableColliderDamage();
    }

    public void EnableLeftDamageCollider()
    {
        leftHandDamageCollider.EnableColliderDamage();
    }

    public void DisableRightHandCollider()
    {
        rightHandDamageCollider.DisableColliderDamage();
    }

    public void DisableLeftHandCollider()
    {
        leftHandDamageCollider.EnableColliderDamage();
    }

    #endregion
}
