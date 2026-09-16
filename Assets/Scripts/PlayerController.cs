using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 6f;
    
    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Chamado automaticamente pelo Player Input Component quando a ação Move dispara
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Chamado automaticamente pelo Player Input Component quando a ação Jump dispara
    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Garante que o pulo só seja ativado novamente ao tocar no chão ou plataformas
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}