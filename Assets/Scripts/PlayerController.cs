using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            if (_instance == null) Debug.LogError("Player is null");
            return _instance;
        } 
    }
    
    //Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity = new Vector3(0f,0f,0f);

    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    [SerializeField] private int collectibles;
    [SerializeField] private int foodPoints;
    [SerializeField] private int startFood;
    
    //References
    private CharacterController controller;
    private Animator anim;
    private Transform catDirection;

    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        catDirection = this.transform.GetChild(0).transform;

        collectibles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        UIManager.Instance.UpdateCoinText(collectibles);
    }

    
    void PlayerMovement()
    {
        if(moveDirection != Vector3.zero)
            catDirection.rotation = Quaternion.LookRotation(moveDirection);

        //----------------------------------------------------------

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        moveDirection = new Vector3(hor, 0, ver);

        if(controller.isGrounded)
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
        anim.SetFloat("Speed", 0f);
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

    public void AddCollectible()
    {
        collectibles++;
    }
}
