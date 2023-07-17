using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotClass : MonoBehaviour
{
    // Here is the whole logic of Robot stats: health points, components, inventory, etc.

    protected Rigidbody rb;

    [Header("Ground Check")]
    [SerializeField] protected Transform groundCheckPos;
    [SerializeField] protected LayerMask groundLayerMask;
    [SerializeField] protected float groundCheckRadius;
    internal bool _isGrounded;

    [Header("Movement")]
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float runSpeed;

    protected Vector3 moveAmount;
    protected Vector3 smoothMoveVelocity;

    [Header("Jumping")]
    [SerializeField] protected float jumpForce;

    [Header("Crouch")]
    [SerializeField] protected float crouchSpeed = 1f;
    [SerializeField] protected float crouchYScale = 0.75f;
    [SerializeField] protected float normalYScale = 1f;

    
    private void Awake()
    {
        /*characterInput = new CharacterInput();
        characterInput.Robot.Enable();*/
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update() { }

    private void FixedUpdate()
    {
        
        /*_isGrounded = GroundCheck;
        Move();
        Jump();
        Crouch();*/
    }

    /*private void Movement(float speedValue)
    {
        Vector2 inputVector = characterInput.Robot.Move.ReadValue<Vector2>();
        inputVector.Normalize();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 targetMoveAmount = moveDirection * speedValue;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

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
    }*/
}
