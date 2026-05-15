using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    private float horizontal;

    public float speed = 8f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform frontWheel;
    [SerializeField] private Transform rearWheel;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Animator animator;

    public float rayLength = 2f;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (horizontal < 0)
        {
            animator.SetBool("isReverse", true);
        }
        else
        {
            animator.SetBool("isReverse", false);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D frontHit = Physics2D.Raycast(
            frontWheel.position,
            Vector2.down,
            rayLength,
            groundLayer
        );

        RaycastHit2D rearHit = Physics2D.Raycast(
            rearWheel.position,
            Vector2.down,
            rayLength,
            groundLayer
        );

        if (frontHit && rearHit)
        {
            // Angle from rear wheel to front wheel
            Vector2 slopeDirection =
                (frontHit.point - rearHit.point).normalized;

            // Move along slope
            rb.linearVelocity = slopeDirection * horizontal * speed;

                // Rotate train
            float angle = Mathf.Atan2(
                slopeDirection.y,
                slopeDirection.x
                ) * Mathf.Rad2Deg;
            
            transform.rotation =
                Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(0, 0, angle),
                10f * Time.fixedDeltaTime
                );

            Debug.Log(angle);
        }
    }
}