using UnityEngine;

public class GenericCharacterStats : MonoBehaviour
{
    [Header("Generic Stats")]
    [SerializeField] protected int maxLife;
    protected int life;
    [SerializeField] protected int maxMana;
    protected int mana;

    protected AnimatorHandler anim;

    public virtual void TakeDamage(int damage)
    {
        life -= damage;
        
        if(life <= 0)
            anim.PlayAnimation("Death", true);
        else
            anim.PlayAnimation("TakeDamage", true);
    }
}