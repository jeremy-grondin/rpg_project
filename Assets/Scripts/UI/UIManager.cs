using UnityEngine;

public class UIManager : MonoBehaviour
{ 
    HealthBar healthBar;

    public void UpdateHealthBar(int life)
    {
        healthBar.SetCurrentHealth(life);
    }

    public void UpdateManaBar(int mana)
    {
        
    }
}
