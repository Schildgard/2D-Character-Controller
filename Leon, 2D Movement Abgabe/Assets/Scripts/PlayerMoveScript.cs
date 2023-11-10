    
using System.Globalization;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private Vector2 groundCheckTransformSize;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask platformLayer;

    [SerializeField] private int maxGravScale;
    [SerializeField] private float holdGravityScale;

    [SerializeField] private float jumpTimeCounter;
    [SerializeField] private float jumpTimeTolerance;


    private float horizontalInput;
    public int jumpCharges;
    public int maxJumpCharges = 1;
    
    public bool jumpButton;
    public bool isGrounded;
    public bool holdJumpbutton;

    private Rigidbody2D rg;
    private SpriteRenderer playerSprite;
    public Vector2 playerVelocity;
    
   


    // Start is called before the first frame update
    void Start()
    {
       rg = GetComponent<Rigidbody2D>();
       playerSprite = GetComponent<SpriteRenderer>();
       playerVelocity = rg.velocity;
      
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        PlayerMove();

        #region Jump Mechanic

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpButton = true;
        }
        if (Input.GetKey(KeyCode.W) && jumpCharges >0)  // hold Button to jump Higher
        {   
            rg.gravityScale = holdGravityScale;
        }
        else
        {
            rg.gravityScale = maxGravScale;
        }

        if(jumpButton)
        {
            jumpTimeCounter += 1 * Time.deltaTime;
        }
        else
        {
            jumpTimeCounter = 0;
        }

        if (rg.velocity.y < -0.01)
        {
            rg.gravityScale = maxGravScale;  // restore Gravity scale when falling down
        }
        #endregion

        #region PlayerFlip

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
        Collider2D col;
        Collider2D col2;
        col = Physics2D.OverlapBox(groundCheckTransform.position, groundCheckTransformSize, 0f, groundLayer);

        if (col != null)
        {
            isGrounded = true;
            jumpCharges = maxJumpCharges;
            
        }
        else
        {
            isGrounded = false;
        }

        col2 = Physics2D.OverlapBox(groundCheckTransform.position, groundCheckTransformSize, 0f, platformLayer);

        if (col2 != null)
        {

        }
        else
        {

        }

        #endregion
    }

    void FixedUpdate()
    {
        if (jumpButton && isGrounded)
        {
            Jump();

        }
        else if (jumpButton && !isGrounded && jumpCharges > 0)
        {
             
             Jump();
             jumpCharges -= 1;
        }
        else if (jumpButton && !isGrounded && jumpCharges == 0 && jumpTimeCounter >= jumpTimeTolerance)
        {
            jumpButton = false;
            
        }
    }


    public void PlayerMove()
    {
        rg.velocity = new Vector2(horizontalInput * moveSpeed, rg.velocity.y);
    }

    public void Jump()
    {
        rg.velocity = playerVelocity;
        rg.AddForce( Vector2.up*jumpPower, ForceMode2D.Impulse);
        jumpButton = false;
    }


   void OnDrawGizmos()
   {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckTransform.position,groundCheckTransformSize);

   }


}

