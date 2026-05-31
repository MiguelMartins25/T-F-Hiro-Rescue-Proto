using Unity.Mathematics;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject Smoke;
    private Transform obstacleLocation;
    //Radius of collison check
    [SerializeField] private float playerDetectionRadius;
    //Pivot of player collision area
    [SerializeField] private LayerMask player;
    [SerializeField] private AudioClip disappearSound;
    [SerializeField] private float audioScale;
    private bool onCollision;
    [SerializeField] private AudioSource audioSource;
    private bool destroy = false;
    private Vector3 equalValues;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        equalValues = this.gameObject.transform.position;
        obstacleLocation = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetect();

        if (onCollision == true && destroy == true)
        {
            Instantiate(Smoke, equalValues, quaternion.identity);
            audioSource.PlayOneShot(disappearSound, audioScale);
            Destroy(gameObject);
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
