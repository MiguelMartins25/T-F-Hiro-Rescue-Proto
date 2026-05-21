using System;
using Unity.VisualScripting;
using UnityEngine;

public class WhistleTracks : MonoBehaviour
{
    private GameObject railsUp;
    private GameObject railsDown;
    private GameObject disabledArea;
    private GameObject forceUp;
    private GameObject forceDown;
    private float cooldownTimer = 0.0f;
    [SerializeField] private float railChangeCooldown = 1.5f;
    private bool space = false;
    private bool railState = false;
    private bool disable = false;
    private bool forceRailsUp = false;
    private bool forceRailsDown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        railsDown = this.transform.GetChild(0).gameObject;
        railsUp = this.transform.GetChild(1).gameObject;


        railsUp.gameObject.SetActive(false);
        railsDown.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        space = Input.GetKeyDown("space");

        if (space == true)
        {
            Debug.Log("it works");
            Debug.Log(cooldownTimer);
        }

        if (cooldownTimer < railChangeCooldown)
            cooldownTimer = cooldownTimer + Time.fixedDeltaTime;

        if (space == true && railState == false && disable == false)
        {
            if (cooldownTimer >= railChangeCooldown)
            {
                railsUp.gameObject.SetActive(true);
                railsDown.gameObject.SetActive(false);
                cooldownTimer = 0.0f;
                railState = true;
            }
        }

        if (space == true && railState == true && disable == false)
        {
            if (cooldownTimer >= railChangeCooldown)
            {
                railsUp.gameObject.SetActive(false);
                railsDown.gameObject.SetActive(true);
                cooldownTimer = 0.0f;
                railState = false;
            }
        }       
    }
    
    public void DisableWhistle(bool allow)
    {
        disable = !allow;
    }

    public void ForceRailsUp(bool allow)
    {
        disable = !allow;
        railsUp.gameObject.SetActive(true);
        railsDown.gameObject.SetActive(false);
    }

    public void ForceRailsDown(bool allow)
    {
        disable = !allow;
        railsUp.gameObject.SetActive(false);
        railsDown.gameObject.SetActive(true);
    }
}
