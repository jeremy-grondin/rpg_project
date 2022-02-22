using UnityEngine;

public class GenericCharacterStats : MonoBehaviour
{
    [Header("Generic Stats")]
    [SerializeField] protected int maxLife;
    protected int life;
    [SerializeField] protected int maxMana;
    protected int mana;
    
    public HealthBar healthBar;

    AnimatorHandler anim;

    private void Start()
    {
        life = maxLife;
        healthBar.SetMaxHealth(maxLife);
        anim = GetComponentInChildren<AnimatorHandler>();
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        healthBar.SetCurrentHealth(life);
        
        if(life <= 0)
            anim.PlayAnimation("Death", true);
        else
            anim.PlayAnimation("TakeDamage", true);
    }
}