using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 25f;
    private bool isFacingRight = true;

    private Animator anim;
    private AudioManager audioManager;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Play jump sound
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            audioManager.Play("boing");
        }

        // Cut jump short
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        // Play dirt sound when grounded and moving
        if (IsGrounded() && Mathf.Abs(horizontal) > 0.1f)
        {
            if (!audioManager.IsPlaying("dirt"))
                audioManager.Play("dirt");
        }

        // Animator parameters
        anim.SetFloat("xMovement", horizontal);
        anim.SetFloat("yMovement", rb.linearVelocity.y);
        anim.SetBool("isJumping", !IsGrounded());
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    
}
