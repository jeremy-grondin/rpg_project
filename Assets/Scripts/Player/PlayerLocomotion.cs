using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Transform cameraTransform;
    InputHandler input;
    Vector3 moveDir;

    [HideInInspector]
    public Rigidbody rb;

    [HideInInspector]
    public GameObject normalCamera;

    AnimatorHandler anim;

    [Header("Movement Stats")]
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<InputHandler>();
        cameraTransform = Camera.main.transform;
        anim = GetComponentInChildren<AnimatorHandler>();
        anim.Initialize();
    }

    #region Movement

    Vector3 normalVector;
    Vector3 targetPosition;

    public void MoveAndRotate()
    {
        input.UpdateInput();

        moveDir = cameraTransform.forward * input.vertical + cameraTransform.right * input.horizontal;
        moveDir.Normalize();
        moveDir.y = 0f;

        moveDir *= movementSpeed;

        rb.velocity = Vector3.ProjectOnPlane(moveDir, normalVector);

        anim.UpdateAnimatorValues(input.moveAmount, 0f);

        if (anim.canRotate)
            HandleRotation();
    }

    private void HandleRotation()
    {
        Vector3 targetDir = Vector3.zero;

        targetDir = cameraTransform.forward * input.vertical;
        targetDir += cameraTransform.right * input.horizontal;

        targetDir.Normalize();
        targetDir.y = 0f;

        if (targetDir == Vector3.zero)
            targetDir = transform.forward;

        Quaternion rotation = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.rotation = targetRotation;
    }
    #endregion
}
