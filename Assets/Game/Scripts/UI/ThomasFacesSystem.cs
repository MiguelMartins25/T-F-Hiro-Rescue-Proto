using UnityEngine;

public class ThomasFacesSystem : MonoBehaviour
{
    private float playerSpeed;
    private GameObject Foward;
    private GameObject Idle;
    private GameObject Backwards;
    private GameObject WhistleFace;
    private GameObject CollisionFace;
    private GameObject WinningSmile;
    private bool whistling = false;
    private bool collision = false;
    private bool levelEnd = false;
    private float collisionTimer = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Foward = gameObject.transform.GetChild(0).gameObject;
        Idle = gameObject.transform.GetChild(1).gameObject;
        Backwards = gameObject.transform.GetChild(2).gameObject;
        WhistleFace = gameObject.transform.GetChild(3).GetChild(1).gameObject;
        CollisionFace = gameObject.transform.GetChild(3).GetChild(0).gameObject;
        WinningSmile = gameObject.transform.GetChild(3).GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSpeed > 0)
        {
            Foward.SetActive(true);
            Idle.SetActive(false);
            Backwards.SetActive(false);
        }

        if(playerSpeed == 0)
        {
            Foward.SetActive(false);
            Idle.SetActive(true);
            Backwards.SetActive(false);
        }

        if(playerSpeed < 0)
        {
            Foward.SetActive(false);
            Idle.SetActive(false);
            Backwards.SetActive(true);
        }

        if (whistling)
        {
            WhistleFace.SetActive(true);
            collisionTimer = 2.0f;
        }
        
        if (collision)
        {
            CollisionFace.SetActive(true);
            collisionTimer = 1.0f;
        }

        if (collisionTimer > 0.0f)
        {
            collisionTimer -= 2 * Time.deltaTime;
            if (collisionTimer <= 0.0f)
            {
                CollisionFace.SetActive(false);
                WhistleFace.SetActive(false);
            }
        }

        if(levelEnd == true)
            WinningSmile.SetActive(true);
        else
            WinningSmile.SetActive(false);
    }

    public void CurrentPlayerSpeed(float speed)
    {
        playerSpeed = speed;
    }

    public void IfWhistle(bool whistle)
    {
        whistling = whistle;
    }

    public void IfCollision(bool hasCollided)
    {
        collision = hasCollided;
    }

    public void LevelEndSmile(bool hasEnded)
    {
        levelEnd = hasEnded;
    }
}
