using UnityEngine;

public class DisableWhistle : MonoBehaviour
{
    [SerializeField] private GameObject whistleRails;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        WhistleTracks controller = whistleRails.GetComponent<WhistleTracks>();
        controller.DisableTrackChange(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        WhistleTracks controller = whistleRails.GetComponent<WhistleTracks>();
        controller.DisableTrackChange(false);
    }
}
