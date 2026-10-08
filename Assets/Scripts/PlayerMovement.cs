using Unity.VisualScripting;
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

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(movementInputX * moveSpeed, rb2d.linearVelocity.y);
    }

    public void OnMove(InputValue value)
    {
        movementInputX = value.Get<Vector2>().x;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && !isJumping)
        {
            isJumping = true;
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
