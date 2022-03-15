using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : GenericCharacterStats
{
    public static Action<int> OnLifeChange;
    
    void Start()
    {
        life = maxLife;
        anim = GetComponentInChildren<AnimatorHandler>();
    }
    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        OnLifeChange?.Invoke(life);
    }
    
}
