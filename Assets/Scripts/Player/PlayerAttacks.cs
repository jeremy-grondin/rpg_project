using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    AnimatorHandler anim;

    private void Awake()
    {
        anim = GetComponentInChildren<AnimatorHandler>();
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        anim.PlayAnimation(weapon.lightAttack, true);
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
        anim.PlayAnimation(weapon.heavyAttack, true);
    }
}
