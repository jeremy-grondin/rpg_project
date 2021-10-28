using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();

        if (player)
            player.TakeDamage(1);
    }
}
