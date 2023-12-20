// ---------------------------------------------
// ---------------------------------------------
// Creation Date: 2023-12-10
// Author: Testes Parada88 
// Project Name: junio 
// Description: 
// 
// ---------------------------------------------
// ---------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    //Input fields
    private ThirdPersonActionsAsset playerActionsAsset;
    private InputAction move;

    //movement fields
    private Rigidbody rb;
    [SerializeField] private float movementForce = 1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float maxSpeed = 5f;

    [SerializeField] private float rotationSpeed = 5f;

    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] private Camera playerCamera;
    private Animator animator;

    Quaternion targetRotation;

    [Header ("Combat")]
    public bool isAttacking = false;
    public bool isDead = false;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerActionsAsset = new ThirdPersonActionsAsset();
        animator = this.GetComponent<Animator>();
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        playerActionsAsset.Player.Jump.started += DoJump;
        playerActionsAsset.Player.Fire1.started += Fire1;
        playerActionsAsset.Player.Fire2.started += Fire2;

        //For testing purpooses
        playerActionsAsset.Player.Kill.started += DoKill;

        move = playerActionsAsset.Player.Move;

        playerActionsAsset.Player.Enable();
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        playerActionsAsset.Player.Jump.started -= DoJump;
        playerActionsAsset.Player.Fire1.started -= Fire1;
        playerActionsAsset.Player.Fire2.started -= Fire2;

        //For testing purpooses
        playerActionsAsset.Player.Kill.started -= DoKill;

        playerActionsAsset.Player.Disable();
    }

    private void FixedUpdate()
    {
        if( this.isDead)
            return;

        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if( rb.velocity.y < 0f )
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if( horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed )
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if( move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f ) {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
            this.rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if( IsGrounded() )
        {
            animator.SetTrigger("Jump");
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        return Physics.Raycast(ray, out RaycastHit hit, 0.3f) ? true : false;
    }

    #region - Events -

    public void StartAttacking()
    {
        this.isAttacking = true;
    }

    public void FinishAttacking()
    {
        this.isAttacking = false;
    }

    public void DoKill(InputAction.CallbackContext obj)
    {
        this.isDead = true;
        animator.SetTrigger("Kill");
    }

    #endregion


    #region - Combat -

    private void Fire1(InputAction.CallbackContext obj)
    {
        if( !this.isAttacking )
        {
            StartAttacking();
            animator.SetTrigger("Fire1");
        }

        FinishAttacking();
    }

    private void Fire2(InputAction.CallbackContext obj)
    {
        if( !this.isAttacking )
        {
            StartAttacking();
            animator.SetTrigger("Fire2");
        }

        FinishAttacking();
    }


    #endregion
}

