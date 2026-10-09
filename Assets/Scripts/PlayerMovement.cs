using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb2d;
    private float movementInputX;

    [Header("Jump")]
    private float jumpForce = 10f;
    private bool isJumping = false;

    [Header("Animation")]
    private Animator animator;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // OnMoveOld(); // อันนี้คือ input เก่า
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(movementInputX * moveSpeed, rb2d.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isJumping = false;
                    break;
                }
            }
        }
    }

    private void Flip()
    {
        if (movementInputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementInputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void UpdateAnimation()
    {
        if (movementInputX != 0 && !isJumping)
        {
            animator.SetInteger("PlayerAction", 1);
        }
        else
        {
            animator.SetInteger("PlayerAction", 0);
        }
    }

    public void Die()
    {
        animator.SetInteger("PlayerAction", 5);
    }

    #region [Input New] // comment อันนี้ถ้าจะใช้ input แบบเก่า ลบ comment ในบรรทัด OnMoveOld(); ใน Update() ออกด้วย

    public void OnMove(InputValue value)
    {
        movementInputX = value.Get<Vector2>().x;

        Flip();
    }

    public void OnJump(InputValue value) 
    {
        if (value.isPressed && !isJumping)
        {
            isJumping = true;
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
        }
    }

    #endregion

    #region [Input Old] // comment ในบรรทัด OnMoveOld(); ใน Update() ถ้าจะใช้ input แบบใหม่

    private void OnMoveOld()
    {
        movementInputX = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
        }

        Flip();
    }

    #endregion
}
