using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    BoxCollider damageCollider;

    private void Awake()
    {
        damageCollider = GetComponent<BoxCollider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableColliderDamage()
    {
        damageCollider.enabled = true;
    }

    public void DisableColliderDamage()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerStats playerStat = GetComponent<PlayerStats>();

            if(playerStat)
            {
                //get weapon damage from weapon item SO
                playerStat.TakeDamage(2);
            }
        }

        if (other.tag == "Enemy")
        {
            Debug.Log("hit");
            EnemyStats enemy = GetComponent<EnemyStats>();
            if(enemy)
                enemy.TakeDamage(2);
        }
    }
}
