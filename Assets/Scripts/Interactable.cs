using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 2.0f;
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, radius);
    }

    public virtual void Interact(PlayerManager playerManager)
    {
        
    }
}
