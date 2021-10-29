using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    AnimatorHandler anim;

    public string lastAttack;

    private void Awake()
    {
        anim = GetComponentInChildren<AnimatorHandler>();
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        anim.PlayAnimation(weapon.lightAttack, true);
        lastAttack = weapon.lightAttack;
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
        anim.PlayAnimation(weapon.heavyAttack, true);
        lastAttack = weapon.heavyAttack;
    }

    public void Combo(WeaponItem weapon)
    {
        anim.anim.SetBool("CanCombo", false);
        if (lastAttack == weapon.lightAttack)
            anim.PlayAnimation(weapon.lightAttack2, true);
    }
}
