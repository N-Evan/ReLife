using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMovement = 0f;
    public float moveSpeed = 10f;
    private bool facingRight = true;

    public float jumpForce = 500f;
    public int jumpCount = 2;
    private int currentJump;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        currentJump = jumpCount;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(horizontalMovement, 0f, 0f) * Time.fixedDeltaTime;
    }

    private void Movement()
    {
        if (!PauseScreen.pauseCheck)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;

            if (horizontalMovement < 0 && facingRight)
            {
                FlipPlayer();
            }
            else if (horizontalMovement > 0 && !facingRight)
            {
                FlipPlayer();
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        if (currentJump > 0)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            currentJump -= 1;
            FindObjectOfType<AudioManager>().Play("playerJump");
            Debug.Log("Jump success!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentJump = jumpCount;
    }
}
