using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed = 1;
    [SerializeField] private float runSpeed = 5;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight = 2;
    
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;

    //References
    private CharacterController controller;
    private Animator anim;
    private Transform catDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        catDirection = this.transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void calcuateNewMovementVector()
    {
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * moveSpeed;
    }

    void PlayerMovement()
    {
        calcuateNewMovementVector();
        
        if(moveDirection != Vector3.zero)
            catDirection.rotation = Quaternion.LookRotation(moveDirection);

        //----------------------------------------------------------

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        moveDirection = new Vector3(hor, 0, ver);

        if(isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        } else
        {
            anim.SetFloat("Speed", 0.79f);
        }

        

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.33f);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 0.66f);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetFloat("Speed", 0.79f);
    }
}
