using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public WeaponItem rightWeapon;
    public WeaponItem leftWeapon;

    WeaponSlotManager weaponSlotManager;

    public WeaponItem[] weaponsForRightHand = new WeaponItem[1];
    public WeaponItem[] weaponsForLefttHand = new WeaponItem[1];

    [HideInInspector] public int currentWeaponRightIndex = 0;
    [HideInInspector] public int currentWeaponLeftIndex = 0;
    
    public List<WeaponItem> weapons = new List<WeaponItem>();

    private void Awake()
    {
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start()
    {
        rightWeapon = weaponsForRightHand[currentWeaponRightIndex];
        leftWeapon = weaponsForLefttHand[currentWeaponLeftIndex];
        weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
        weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
    }

    public void ChangeWeaponRightHand()
    {
        currentWeaponRightIndex += 1;

        if (currentWeaponRightIndex >= weaponsForRightHand.Length)
            currentWeaponRightIndex = 0;

        if (weaponsForRightHand[currentWeaponRightIndex] != null)
        {
            rightWeapon = weaponsForRightHand[currentWeaponRightIndex];
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
        }
    }
}