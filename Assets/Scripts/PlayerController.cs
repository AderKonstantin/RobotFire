using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Here is the whole logic of character control: input, movement.

    private Rigidbody rb;
    internal static CharacterInput characterInput;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float groundCheckRadius;
    bool _isGrounded;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveAmount;
    private Vector3 smoothMoveVelocity;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;

    [Header("Crouch")]
    [SerializeField] private float crouchSpeed = 1f;
    [SerializeField] private float crouchYScale = 0.75f;
    [SerializeField] private float normalYScale = 1f;

    private void Awake()
    {
        characterInput = new CharacterInput();
        characterInput.Robot.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _isGrounded = GroundCheck; // dubious decision? Maybe it's worth moving to FixedUpdate?
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        Crouch();
    }

    private void Movement(float speedValue)
    {
        Vector2 inputVector = characterInput.Robot.Move.ReadValue<Vector2>();
        inputVector.Normalize();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 targetMoveAmount = moveDirection * speedValue;
        moveAmount = Vector3.SmoothDamp (moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
        
        if (inputVector != Vector2.zero)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        }
    }
    
    private void Move()
    {
        if (characterInput.Robot.Run.IsInProgress())
        {
            Movement(runSpeed);
        }
        else if (characterInput.Robot.Crouch.IsInProgress())
        {
            Movement(crouchSpeed);
        }
        else
        {
            Movement(moveSpeed);
        }
    }

    private void Jump()
    {
        if (characterInput.Robot.Jump.IsInProgress() && _isGrounded)
        {
            Debug.Log("Jump");
            rb.AddForce(transform.up * jumpForce * Mathf.Abs(Physics.gravity.y));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckRadius);
    }
    private bool GroundCheck => Physics.CheckSphere(groundCheckPos.position, groundCheckRadius, groundLayerMask);

    private void Crouch()
    {
        if (characterInput.Robot.Crouch.IsInProgress() && _isGrounded)
        {
            // Crouch Function
            Debug.Log("Crouch");
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, normalYScale, transform.localScale.z);
        }
    }
}
