using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    DamageCollider leftHandDamageCollider;
    DamageCollider rightHandDamageCollider;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

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
            anim.CrossFade(weapon.leftHandIdle, 0.2f);
        }
        else
        {
            rightHandSlot.LoadWeaponModel(weapon);
            LoadRightHandDamageCollider();
            anim.CrossFade(weapon.rightArmIdle, 0.2f);
        }
    }

    #region Weapon damage collider

    private void LoadLeftHandDamageCollider()
    {
        leftHandDamageCollider = leftHandSlot.GetComponentInChildren<DamageCollider>();
    }

    private void LoadRightHandDamageCollider()
    {
        //rightHandDamageCollider = null;
        //rightHandDamageCollider = rightHandSlot.GetComponentInChildren<DamageCollider>();
        //Debug.Log(rightHandDamageCollider.name);
    }

    public void EnableRightDamageCollider()
    {
        rightHandSlot.GetComponentInChildren<DamageCollider>().EnableColliderDamage();
    }

    public void EnableLeftDamageCollider()
    {
        leftHandDamageCollider.EnableColliderDamage();
    }

    public void DisableRightHandCollider()
    {
        rightHandSlot.GetComponentInChildren<DamageCollider>().DisableColliderDamage();
    }

    public void DisableLeftHandCollider()
    {
        leftHandDamageCollider.EnableColliderDamage();
    }

    #endregion
}
