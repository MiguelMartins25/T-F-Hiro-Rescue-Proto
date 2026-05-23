using UnityEngine;

public class Whistle : MonoBehaviour
{
    private float cooldownTimer = 0.0f;
    [SerializeField] private float whistleCooldown = 1.5f;
    [SerializeField] private GameObject ScriptThatUsesWhistle1;
    private bool space = false;
    private bool whistle = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        space = Input.GetKeyDown("space");

        if (space == true)
        {
            if (cooldownTimer >= whistleCooldown)
            {
                whistle = true;
                cooldownTimer = 0.0f;
            }
        }
        else
        {
            whistle = false;
        }

        WhistleTracks controller = ScriptThatUsesWhistle1.GetComponent<WhistleTracks>();
        controller.ActiveWhistle(whistle);
    }

    void FixedUpdate()
    {

        if (cooldownTimer < whistleCooldown)
            cooldownTimer = cooldownTimer + Time.fixedDeltaTime;
    
    }

    
}
