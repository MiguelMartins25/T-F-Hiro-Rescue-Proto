using OkapiKit;
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
    //End the level detection
    [SerializeField] private LayerMask levelEndTouch;

    private Rigidbody2D     rb;
    private bool            onGround;
    private bool            onCollision;
    private bool            levelEnd;
    private float           collisionTimer = 0.0f;
    [SerializeField] private float puffingCooldown = 0.0f;

    //Place to put audio in
    public AudioClip puffing;
    //Bool to known when player is moving
    private bool isPuffing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //RigidBody of Player
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Called Methods
        GroundDetect();
        CollisionDetect();
        LevelEnd();

        //player horizontal input
        float dx = Input.GetAxis("Horizontal");

        //Calculations for player velocity
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

        //Makes the player speed decrease faster when input comes from oposite direction of movement
        if ((dx > 0 && aceleration < 0) || (dx < 0 && aceleration > 0))
            aceleration = 0;

        //Vector of player movement
        rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);

        //Makse the player charcater stop on slopes
        if (dx == 0 && onGround == true)
            rb.gravityScale = 0;
        else
            rb.gravityScale = movingGravity;
        
        //Makes the player bounce when colliding with an object of the collision layer
        collisionTimer += Time.deltaTime;
        if ((speed > 0 && onCollision == true) || (speed < 0 && onCollision == true))
            if (collisionTimer > collisionCooldown)
            {
                speed = -speed/2;
                collisionTimer = 0.0f;
            }
        
        //Makes the puff sound when the player is moving
        if (speed != 0)
        {
            if (!isPuffing)
            {
                //Invokes the method at an interval
                InvokeRepeating(nameof(PuffingSounds), 0f, puffingCooldown);
                isPuffing = true;
            }
        }
        else
        {
            if (isPuffing)
            {
                //Cancels the invokation
                CancelInvoke(nameof(PuffingSounds));
                isPuffing = false;
            }
        }

        //makes the player unable to move at the end of the level
        if (levelEnd == true)
        {
            speed = 0;
        }
    }

    //puffing sound player
    void PuffingSounds()
    {
        SoundManager.PlaySound(puffing);
    }
    
    //checks for player and level collidable collision
    void CollisionDetect()
    {
        onCollision = false;

        Collider2D colliding = Physics2D.OverlapCircle(playerPivot.position, collisionDetectionRadius, collisionLayer);
        if (colliding != null)
            onCollision = true;
    }

    //checks for player and ground collisions to be able to stop on slopes
    void GroundDetect()
    {
        onGround = false;

        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (collider != null)
            onGround = true;
    }

    //Visualize ground check
    void OnDrawGizmosSelected()
    {
        if (groundCheck)
        {
            Gizmos.color = (onGround) ? (Color.black) : (Color.red);
            Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
        }
    }

    //tells the scrpt that the level has ended
    void LevelEnd()
    {
        levelEnd = false;

        Collider2D end = Physics2D.OverlapCircle(playerPivot.position, collisionDetectionRadius, levelEndTouch);
        if (end != null)
            levelEnd = true;
    }
}