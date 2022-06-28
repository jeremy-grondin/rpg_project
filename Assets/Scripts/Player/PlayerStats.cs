using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int maxLife = 10;

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
