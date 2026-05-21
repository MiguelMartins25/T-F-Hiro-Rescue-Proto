using UnityEngine;

public class DisableWhistle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player"))
          return;

        WhistleTracks controller =
            other.GetComponent<WhistleTracks>();

        if (controller != null)
        {
            controller.DisableWhistle(true);
            Debug.Log("Rail changing disabled");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        WhistleTracks controller =
            other.GetComponent<WhistleTracks>();

        if (controller != null)
        {
            controller.DisableWhistle(false);
            Debug.Log("Rail changing enabled");
        }
    }
}
