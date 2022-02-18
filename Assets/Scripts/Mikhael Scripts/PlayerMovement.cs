using System.Collections;
using UnityEngine;

//Mikhaels kod

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpPower = 15f;
    public int extraJumps = 1;
    public Animator animator;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;

    int jumpCount = 0;
    public bool isGrounded;
    float mx;
    float jumpCoolDown;

    public float dashDistance = 15f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;

    float dashCoolDown;

    public AudioClip jumpClip;//Melker

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        mx = Input.GetAxis("Horizontal"); //a d i det fallet

        animator.SetFloat("Speed", Mathf.Abs(mx));

        if (dashCoolDown > 0)
        {
            dashCoolDown -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump")) //space
        {
            AudioSource.PlayClipAtPoint(jumpClip, transform.position);//Melker
            Jump();
            animator.SetBool("IsJumping", true);
        }

        //dash åt vänster
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A && dashCoolDown <= 0) //ifall man dubbeltrycker på A (samma med D) så blir dash cooldown resettad
            {
                StartCoroutine(Dash(-1f));
            } else
            {
                doubleTapTime = Time.time + 0.5f;
            }

            //AudioSource.PlayClipAtPoint(walkingClip, transform.position);//Melker

            lastKeyCode = KeyCode.A;
        }

        //dash åt höger
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D && dashCoolDown <= 0)
            {
                StartCoroutine(Dash(1f));
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }

            //AudioSource.PlayClipAtPoint(walkingClip, transform.position);//Melker

            lastKeyCode = KeyCode.D;

        }

        CheckGrounded();
    }

   


    private void FixedUpdate()
    {
        if (!isDashing)
        rb.velocity = new Vector2(mx * speed, rb.velocity.y);
        if (Mathf.Abs(mx) >= 0.05f && !source.isPlaying) //ifall hastigheten är mer eller lika med 0.05 och den inte spelas så börjar den spelas
        {
            source.Play();
        }
    }

    void Jump ()
    {
        if (isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower); //när man är på marken så får man en till hopp
            jumpCount++;
        }
    }

    void CheckGrounded ()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        } else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
        
    }

   IEnumerator Dash (float direction)
    {
        dashCoolDown = 3;
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb.gravityScale = gravity;
    }
}
