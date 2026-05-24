using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Transform obstacleLocation;
    //Radius of collison check
    [SerializeField] private float playerDetectionRadius;
    //Pivot of player collision area
    [SerializeField] private LayerMask player;
    private bool onCollision;
    private GameObject parentObject;
    private bool destroy = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstacleLocation = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetect();

        if (onCollision == true && destroy == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    void PlayerDetect()
    {
        onCollision = false;

        Collider2D colliding = Physics2D.OverlapCircle(obstacleLocation.position, playerDetectionRadius, player);
        if (colliding != null)
            onCollision = true;
    }

    public void DestroyObject(bool allow)
    {
        destroy = allow;
    }
}
