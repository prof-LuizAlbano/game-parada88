// ---------------------------------------------
// ---------------------------------------------
// Creation Date: 2023-11-19
// Author: Testes Parada88 
// Project Name: junio 
// Description: 
// 
// ---------------------------------------------
// ---------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;

    [SerializeField]
    float rotationSpeed = 500f;

    [Header("Ground Check Settings")]

    [SerializeField]
    float groundCheckRadius = 0.45f;

    [SerializeField]
    Vector3 groundCheckOffset = new Vector3(0, 0.45f, 0.18f);

    [SerializeField]
    LayerMask groundLayer;

    bool isGrounded;

    float ySpeed;

    Quaternion targetRotation;

    CameraController cameraController;

    Animator animator;
    CharacterController characterController;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Clamp01( Mathf.Abs(h) + Mathf.Abs(v) );

        var moveInput = (new Vector3(h, 0, v)).normalized;
        var moveDir = cameraController.PlanarRotation * moveInput;

        GroundCheck();
        ySpeed = ( isGrounded ) ? -0.5f : ySpeed + Physics.gravity.y * Time.deltaTime;

        var velocity = moveDir * moveSpeed;
        velocity.y = ySpeed;

        characterController.Move( velocity * Time.deltaTime);

        if( moveAmount > 0 ) {
            targetRotation = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        animator.SetFloat("moveAmount", moveAmount, 0.2f, Time.deltaTime);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
    }

    /// <summary>
    /// Callback to draw gizmos only if the object is selected.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);  
    }
}
