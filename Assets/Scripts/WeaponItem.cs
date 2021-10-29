using UnityEngine;

[CreateAssetMenu(menuName ="Item/Weapon")]
public class WeaponItem : Item
{
    [Header("Weapon Information")]
    public GameObject modePrefab;

    public int weaponDamage = 2;

    [Header("One Handed Attack Animation")]
    public string lightAttack;
    public string lightAttack2;
    public string heavyAttack;
    public string heavyAttack2;
}
