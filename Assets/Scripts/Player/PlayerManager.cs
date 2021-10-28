using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler input;
    PlayerLocomotion playerLocomotion;
    Animator anim;
 

    [HideInInspector]
    public bool isInteracting = false;

    private void Start()
    {
        input = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        playerLocomotion.MoveAndRotate();
    }

    private void LateUpdate()
    {
        input.lightAttack = false;
        input.heavyAttack = false;
    }
}
