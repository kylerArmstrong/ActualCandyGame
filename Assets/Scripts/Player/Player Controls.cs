using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement Controls")]
    public float moveSpeed;

    public float playerHeight;
    public LayerMask groundLayer;
    public bool grounded;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airmultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode phoneKey = KeyCode.Q;

    public Transform orientation;

    float  horizontalInput;
    float verticalInput;

    public bool interactKeyDown;
    public bool interacting;

    public GameObject phoneFolder;

    Vector3 moveDirection;
    Rigidbody rb;

    public bool sitting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //ground check raycast
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        MovementInput();
        SpeedLimit();
        interact();
        phone();

        if(grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    private void phone()
    {
        if(Input.GetKeyDown(phoneKey) && !phoneFolder.activeInHierarchy)
        {
            phoneFolder.SetActive(true);
            interacting = true;
        } 
        else if(Input.GetKeyDown(phoneKey) && phoneFolder.activeInHierarchy)
        {
            phoneFolder.SetActive(false);
            interacting = false;
        }
    }

    private void interact()
    {
        if(Input.GetKey(interactKey))
        {
            interactKeyDown = true;
        }
        else
        {
            interactKeyDown = false;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        if(!sitting)
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            
            if(grounded)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }
            else if(!grounded)
            {
                
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airmultiplier, ForceMode.Force);
            }
        }
    }

    private void SpeedLimit()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }


    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
    
}
