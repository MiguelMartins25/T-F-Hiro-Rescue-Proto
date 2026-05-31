using UnityEngine;

public class ThomasFaces : MonoBehaviour
{
    [SerializeField] private float blinkingInterval;
    private GameObject Open;
    private GameObject Midway;
    private GameObject Closed;
    private float passTime = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Open = gameObject.transform.GetChild(0).gameObject;
        Midway = gameObject.transform.GetChild(1).gameObject;
        Closed = gameObject.transform.GetChild(2).gameObject;

        Open.SetActive(true);
        Midway.SetActive(false);
        Closed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        passTime = passTime + Time.deltaTime;
        if(passTime >= blinkingInterval)
        {
            Blink();
        }
    }

    void Blink()
    {
        if(passTime >= blinkingInterval)
        {
            Open.SetActive(false);
            Midway.SetActive(true);
        }

        if(passTime >= blinkingInterval + 0.1f)
        {
            Midway.SetActive(false);
            Closed.SetActive(true);
        }
        
        if(passTime >= blinkingInterval + 0.2f)
        {
            Closed.SetActive(false);
            Midway.SetActive(true);
        }

        if(passTime >= blinkingInterval + 0.3f)
        {
            Midway.SetActive(false);
            Open.SetActive(true);
            passTime = 0.0f;
        }
    }
}
