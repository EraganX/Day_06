using UnityEngine;
using static GameManager;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float fallMultiplier = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    private bool isJumped;

    public bool isGameOver = false;

    [SerializeField] private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGameOver) return; 

        if (isGrounded) animator.SetBool("Run", true);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("Run", false);
            animator.SetTrigger("Jump");
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if (!isGrounded)
        {
            rb.velocity += Vector3.down * fallMultiplier * Time.fixedDeltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Death", true);

            isGameOver = true;

        }
    }
}
