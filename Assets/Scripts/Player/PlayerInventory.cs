using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public WeaponItem rightWeapon;
    public WeaponItem leftWeapon;

    WeaponSlotManager weaponSlotManager;


    private void Awake()
    {
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start()
    {
        weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
        weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
    }
}
