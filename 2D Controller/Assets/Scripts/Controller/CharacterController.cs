using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rg;
    private SpriteRenderer playerSprite;
    private float horizontalInput;
    private Vector2 playerVelocity;

    [Header("Vertical Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    private float normalMoveSpeed;
    private bool isRunning;

    [Header("Jump Handling")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpInputPuffer;
    [SerializeField] private float jumpTimeTolerance;
    private int jumpCharges = 1;
    private int maxJumpCharges = 1;
    private bool jumpButtonPressed;
    private bool jumpButtonHold;


    [Header("GroundCheck")]
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private Vector2 groundCheckTransformSize;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask platformLayer;
    private bool isGrounded;

    [Header("Gravity Scaling")]
    [SerializeField] private int maxGravScale;
    [SerializeField] private float holdGravityScale;


    #region Properties
    public float HorizontalInput => horizontalInput;
    public bool IsRunning => isRunning;
    #endregion


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        normalMoveSpeed = moveSpeed;

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        MovePlayer();

        #region Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else
        {
            isRunning = false;
        }
        #endregion
        #region Jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpButtonPressed = true;
        }
        if (Input.GetKey(KeyCode.Space) && jumpCharges > 0)  // hold Button to jump Higher
        {
            rg.gravityScale = holdGravityScale;
        }
        else
        {
            rg.gravityScale = maxGravScale;
        }

        if (jumpButtonPressed)
        {
            jumpInputPuffer += 1 * Time.deltaTime;
        }
        else
        {
            jumpInputPuffer = 0;
        }

        if (rg.velocity.y < -0.01)
        {
            rg.gravityScale = maxGravScale;  // restore Gravity scale when falling down
        }
        #endregion
        #region PlipPlayer Direction

        if (horizontalInput > 0.01)
        {
            playerSprite.flipX = false;
        }
        else if (horizontalInput < -0.01)
        {
            playerSprite.flipX = true;
        }
        #endregion
        #region GroundCollisionCheck
        // Check if player stays on ground (col1) or on a moving platform (col2)
        Collider2D col;
        Collider2D col2;
        col = Physics2D.OverlapBox(groundCheckTransform.position, groundCheckTransformSize, 0f, groundLayer);

        // if player stands on ground
        if (col != null)
        {
            isGrounded = true;
            jumpCharges = maxJumpCharges;
        }
        else
        {
            isGrounded = false;
        }
        // if player stands on platform make the player a child of platform so he moves with the platform
        col2 = Physics2D.OverlapBox(groundCheckTransform.position, groundCheckTransformSize, 0f, platformLayer);
        if (col2 != null)
        {
            gameObject.transform.parent = col2.transform;
        }
        else
        {
            gameObject.transform.parent = null;
        }
        #endregion
    }

    void FixedUpdate()
    {
        if (jumpButtonPressed && isGrounded)
        {
            Jump();
        }
        else if (jumpButtonPressed && !isGrounded && jumpCharges > 0)
        {
            Jump();
            jumpCharges -= 1;
        }
        else if (jumpButtonPressed && !isGrounded && jumpCharges == 0 && jumpInputPuffer >= jumpTimeTolerance)
        {
            jumpButtonPressed = false;
        }
    }


    public void MovePlayer()
    {
        if (isRunning)
        {
            moveSpeed = runSpeed;
        }
        else
        {
            if (moveSpeed != normalMoveSpeed)
            {
                moveSpeed = normalMoveSpeed;
            }
        }
        rg.velocity = new Vector2(horizontalInput * moveSpeed, rg.velocity.y);
    }
    public void Run()
    {
        isRunning = true;
    }

    public void Jump()
    {
        rg.velocity = playerVelocity;
        rg.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        jumpButtonPressed = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpCharges = maxJumpCharges;
            jumpButtonPressed = false;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckTransform.position, groundCheckTransformSize);

    }


}

