using Unity.VisualScripting;
using UnityEngine;

public class PlayerThomas : MonoBehaviour
{
    //Character speed
    [SerializeField] private float speed = 0;
    //Aceleration added onto character speed
    [SerializeField] private float aceleration = 0;
    //Max character speed
    [SerializeField] private float maxSpeed = 150;
      //Max character speed
    [SerializeField] private float maxAceleration = 50;
    //Rate of acelaration lost after no inputs
    [SerializeField] private float acelerationDecrease = 1;
    //How fast speed drecreases after reaching 0 aceleration
    [SerializeField] private float frictionPower = 2;
    //Check ground collision
    [SerializeField] private Transform groundCheck;
    //Radius of groundcheck
    [SerializeField] private float groundCheckRadius;
    //Which layer check for ground check
    [SerializeField] private LayerMask groundLayer;
    //Gracity applied to player while moving
    [SerializeField] private float movingGravity = 5;
    //Area for player collision check
    [SerializeField] private Transform playerPivot;
    //Radius of collison check
    [SerializeField] private float collisionDetectionRadius;
    //Pivot of player collision area
    [SerializeField] private LayerMask collisionLayer;
    //Time between bounce of collision
    [SerializeField] private float collisionCooldown;

    private Rigidbody2D     rb;
    private bool            onGround;
    private bool            onCollision;
    private float           collisionTimer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //RigidBody of Player
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GroundDetect();
        CollisionDetect();

        float dx = Input.GetAxis("Horizontal");

        aceleration = aceleration + dx;

        if (aceleration >= maxAceleration)
            aceleration = maxAceleration;
        else if (aceleration <= -maxAceleration)
            aceleration = -maxAceleration;

        speed = speed + aceleration;
        if (speed >= maxSpeed)
            speed = maxSpeed;
        else if (speed <= -maxSpeed)
            speed = -maxSpeed;

        if (dx == 0)
        {
            if (aceleration > acelerationDecrease)
                aceleration = aceleration - acelerationDecrease;
            else if (aceleration < -acelerationDecrease)
                aceleration = aceleration + acelerationDecrease;
            else
                if (aceleration < acelerationDecrease || aceleration > -acelerationDecrease)
                    aceleration = 0;
            
            if (speed > frictionPower)
                speed = speed - frictionPower;
            else if (speed < -frictionPower)
                speed = speed + frictionPower;
            else
                if (speed < frictionPower || speed > -frictionPower)
                    speed = 0; 
        }

        if ((dx > 0 && aceleration < 0) || (dx < 0 && aceleration > 0))
            aceleration = 0;

        rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);

        if (dx == 0 && onGround == true)
            rb.gravityScale = 0;
        else
            rb.gravityScale = movingGravity;
        
        collisionTimer += Time.deltaTime;
        if ((speed > 0 && onCollision == true) || (speed < 0 && onCollision == true))
            if (collisionTimer > collisionCooldown)
            {
                speed = -speed/2;
                collisionTimer = 0.0f;
            }

    }


    void CollisionDetect()
    {
        onCollision = false;

        Collider2D colliding = Physics2D.OverlapCircle(playerPivot.position, collisionDetectionRadius, collisionLayer);
        if (colliding != null)
            onCollision = true;
    }
    void GroundDetect()
    {
        onGround = false;

        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (collider != null)
            onGround = true;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck)
        {
            Gizmos.color = (onGround) ? (Color.black) : (Color.red);
            Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
