using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int maxLife = 10;


    AnimatorHandler anim;

    private void Start()
    {
        life = maxLife;
        anim = GetComponentInChildren<AnimatorHandler>();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("OUCH");
    }
}
