using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    public Animator anim;
    PlayerManager playerManager;
    PlayerLocomotion playerLocomtion;
    int vertical = 0;
    int horizontal = 0;
    public bool canRotate;

    public void Initialize()
    {
        playerManager = GetComponentInParent<PlayerManager>();
        playerLocomtion = GetComponentInParent<PlayerLocomotion>();
        anim = GetComponent<Animator>();
        vertical = Animator.StringToHash("Vertical");
        horizontal = Animator.StringToHash("Horizontal");
        canRotate = true;
    }

    public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement)
    {
        float v = 0f;
        //float h = 0f;

        if (verticalMovement > 0.55f)
            v = 1f;
        else if (vertical < -0.55f)
            v = -1f;
        else
            v = 0f;


        /*if (horizontal > 0f && horizontalMovement < 0.55f)
            h = 0.5f;
        else if (horizontalMovement > 0.55f)
            h = 1f;
        else if (horizontal < 0f && horizontalMovement < -0.55f)
            h = -0.5f;
        else if (horizontal < -0.55f)
            h = -1f;
        else
            h = 0f;*/

        anim.SetFloat(vertical, v, 0.1f, Time.deltaTime);
        //anim.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
    }

    public void CanRotate()
    {
        canRotate = true;
    }

    public void StopRotate()
    {
        canRotate = false;
    }

    public void PlayAnimation(string animName, bool isInteracting)
    {
        anim.applyRootMotion = isInteracting;
        anim.SetBool("IsInteracting", isInteracting);
        anim.CrossFade(animName, 0.2f);
    }

    public void EnableCombo()
    {
        anim.SetBool("CanCombo", true);
    }
    
    public void DisableCombo()
    {
        anim.SetBool("CanCombo", false);
    }

    private void OnAnimatorMove()
    {
        if (!playerManager.isInteracting)
            return;

        playerLocomtion.rb.drag = 0;
        Vector3 pos = anim.deltaPosition;
        pos.y = 0f;
        playerLocomtion.rb.velocity = pos / Time.deltaTime;
    }
}
