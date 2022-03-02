using UnityEngine;

public class GenericAttacks : MonoBehaviour
{
    AnimatorHandler animHandler;

    public string lastAttack;

    private void Awake()
    {
        animHandler = GetComponentInChildren<AnimatorHandler>();
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        animHandler.PlayAnimation(weapon.lightAttack, true);
        lastAttack = weapon.lightAttack;
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
        animHandler.PlayAnimation(weapon.heavyAttack, true);
        lastAttack = weapon.heavyAttack;
    }

    public void Combo(WeaponItem weapon)
    {
        animHandler.anim.SetBool("CanCombo", false);
        if (lastAttack == weapon.lightAttack)
            animHandler.PlayAnimation(weapon.lightAttack2, true);
    }

    public void ComboHeavyAttack(WeaponItem weapon)
    {
        animHandler.anim.SetBool("CanCombo", false);
        if (lastAttack == weapon.heavyAttack)
            animHandler.PlayAnimation(weapon.heavyAttack2, true);
    }
}
