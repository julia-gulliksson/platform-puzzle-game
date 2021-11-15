using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    DefaultControls playerInputActions;
    InputAction movement;
    Vector3 moveVector;

    [SerializeField] Transform groundCheckTransform = null;
    [SerializeField] Transform handgroundCheckTransform = null;
    [SerializeField] LayerMask playerMask;
    [SerializeField] LayerMask handColliderMask;
    [SerializeField] ScoreManager scoreManager;

    Rigidbody rb;
    public bool isGrounded;
    public GameObject gameOverUI;
    float moveSpeed = 3f;
    float rotationSpeed = 15f;

    private void Awake()
    {
        playerInputActions = new DefaultControls();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Move;
        movement.Enable();

        playerInputActions.Player.Jump.performed += HandleJump;
        playerInputActions.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInputActions.Player.Jump.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CheckIfFalling();

        CheckIfGrounded();

        MovePlayer();
    }

    void MovePlayer()
    {
        // Get movement value from WASD/arrow keys inputs
        Vector2 direction = movement.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x * moveSpeed, rb.velocity.y, 0);
        // Make player move on the x axis
        rb.velocity = moveVector;
        // Smooth rotate
        if (moveVector.x != 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveVector.x, 0, 0)), Time.deltaTime * rotationSpeed);
        }
    }

    void CheckIfGrounded()
    {
        if (Physics.OverlapSphere(handgroundCheckTransform.position, 0.1f, handColliderMask).Length != 0)
        {
            // Player is stuck with hands on platform, enable jumping
            isGrounded = true;
        }
        else
        {
            isGrounded = Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length != 0;
        }
    }

    void CheckIfFalling()
    {
        if (rb.position.y <= -1.4f)
        {
            // Player has fallen off the edge, show Game over ui
            gameOverUI.SetActive(true);
        }
    }

    void HandleJump(InputAction.CallbackContext context)
    {
        if (!isGrounded)
        {
            // Player is in the air, return to prevent jump
            return;
        }
        float jumpPower = 5f;

        if (scoreManager.superJumpCoins > 0)
        {
            jumpPower *= 1.5f;
            GameEventsManager.current.SuperJumpUsed();
        }
        rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        AudioManager.current.Play("Jump");
    }
}
