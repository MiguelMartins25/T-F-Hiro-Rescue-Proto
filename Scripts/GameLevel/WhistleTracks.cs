using UnityEngine;

public class WhistleTracks : MonoBehaviour
{
    private GameObject RailsUp;
    private GameObject RailsDown;
    private bool whistle = false;
    private bool railState = false;
    private bool disable = false;
    private bool forceRailsDown = false;
    private bool forceRailsUp = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RailsDown = this.transform.GetChild(0).gameObject;
        RailsUp = this.transform.GetChild(1).gameObject;


        RailsUp.gameObject.SetActive(false);
        RailsUp.gameObject.layer = LayerMask.NameToLayer("Default");
        RailsDown.gameObject.SetActive(true); 
        RailsDown.gameObject.layer = LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if (whistle == true && railState == false && disable == false)
        {
            RailsUp.gameObject.SetActive(true);
            RailsUp.gameObject.layer = LayerMask.NameToLayer("Ground");
            RailsDown.gameObject.SetActive(false);
            RailsDown.gameObject.layer = LayerMask.NameToLayer("Default");
            railState = true;
        }
        else if (whistle == true && railState == true && disable == false)
        {
            RailsUp.gameObject.SetActive(false);
            RailsUp.gameObject.layer = LayerMask.NameToLayer("Default");
            RailsDown.gameObject.SetActive(true);
            RailsDown.gameObject.layer = LayerMask.NameToLayer("Ground");
            railState = false;
        }   
    }
    
    public void DisableTrackChange(bool allow)
    {
        disable = allow;
    }

    public void ActiveWhistle(bool enable)
    {
        whistle = enable;
    }

    public void ForceRailsUp(bool allow)
    {
        forceRailsDown = allow;
        if (forceRailsDown == true)
        {
            RailsUp.gameObject.SetActive(true);
            RailsUp.gameObject.layer = LayerMask.NameToLayer("Ground");
            RailsDown.gameObject.SetActive(false);
            RailsDown.gameObject.layer = LayerMask.NameToLayer("Default");
            forceRailsDown = false;
        }
    }

    public void ForceRailsDown(bool allow)
    {
        forceRailsUp = allow;
        if (forceRailsUp == true)
        {
            RailsUp.gameObject.SetActive(false);
            RailsUp.gameObject.layer = LayerMask.NameToLayer("Default");
            RailsDown.gameObject.SetActive(true);
            RailsDown.gameObject.layer = LayerMask.NameToLayer("Ground");
            forceRailsUp = false;
        }
    }
}
