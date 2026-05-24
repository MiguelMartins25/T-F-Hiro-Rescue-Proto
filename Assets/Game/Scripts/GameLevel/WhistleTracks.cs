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
        RailsDown.gameObject.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        if (whistle == true && railState == false && disable == false)
        {
            RailsUp.gameObject.SetActive(true);
            RailsDown.gameObject.SetActive(false);
            railState = true;
        }
        else if (whistle == true && railState == true && disable == false)
        {
            RailsUp.gameObject.SetActive(false);
            RailsDown.gameObject.SetActive(true);
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
            RailsDown.gameObject.SetActive(false);
            forceRailsDown = false;
        }
    }

    public void ForceRailsDown(bool allow)
    {
        forceRailsUp = allow;
        if (forceRailsUp == true)
        {
            RailsUp.gameObject.SetActive(false);
            RailsDown.gameObject.SetActive(true);
            forceRailsUp = false;
        }
    }
}
