using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    [Header("HUD")]
    HealthBar healthBar;
    public PlayerInventory playerInventory;
    public GameObject pauseWindow;
    public GameObject interactablePanel;
    public Text interactableText;
    
    [Header("Weapon Inventory")]
    public GameObject weaponInventorySlotPrefab;
    public GameObject weaponInventoryWindow;
    public Transform weaponInventorySlotsParent;

    private WeaponInventorySlot[] weaponSlots;

    private void Start()
    {
        weaponSlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
    }

    public void UpdateHealthBar(int life)
    {
        healthBar.SetCurrentHealth(life);
    }

    public void UpdateUI()
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (i < playerInventory.weaponInventory.Count)
            {
                if (weaponSlots.Length < playerInventory.weaponInventory.Count)
                {
                    Instantiate(weaponInventorySlotPrefab, weaponInventorySlotsParent);
                    weaponSlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
                }
                weaponSlots[i].AddItem(playerInventory.weaponInventory[i]);
            }
            else
            {
                weaponSlots[i].ClearSlot();
            }
        }
    }

    public void OpenWindow()
    {
        pauseWindow.SetActive(true);
    }

    public void CloseWindow()
    {
        pauseWindow.SetActive(false);
    }

    public void CloseAllWindows()
    {
        weaponInventoryWindow.SetActive(false);
    }
}
