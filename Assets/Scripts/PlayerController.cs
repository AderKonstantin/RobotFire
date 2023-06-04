using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Here is the whole logic of character control: input, movement.

    private Rigidbody rb;
    internal static CharacterInput characterInput;

    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float groundCheckRadius;
    bool _isGrounded;

    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private float jumpForce = 3.0f;

    private Vector3 moveAmount;
    private Vector3 smoothMoveVelocity;

    private void Awake()
    {
        characterInput = new CharacterInput();
        characterInput.Robot.Enable();
    }

    // Start is called before the first frame update
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
            rb.AddForce(transform.up * jumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckRadius);
    }
    private bool GroundCheck => Physics.CheckSphere(groundCheckPos.position, groundCheckRadius, groundLayerMask);

    private void Crouch() // Test function to check input
    {
        if (characterInput.Robot.Crouch.IsInProgress() && _isGrounded)
        {
            // Crouch Function
            Debug.Log("Crouch");
        }
    }
}
