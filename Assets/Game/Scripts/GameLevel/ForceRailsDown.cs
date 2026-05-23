using UnityEngine;

public class ForceRailsDown : MonoBehaviour
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
        WhistleTracks controller =
            whistleRails.GetComponent<WhistleTracks>();
        controller.ForceRailsDown(true);
        Debug.Log("Rails forced down");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        WhistleTracks controller =
            whistleRails.GetComponent<WhistleTracks>();
        controller.ForceRailsDown(false);
        Debug.Log("Rails forced end");
    }
}
