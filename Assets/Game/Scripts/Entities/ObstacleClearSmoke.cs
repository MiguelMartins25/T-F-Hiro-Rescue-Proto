using UnityEngine;

public class ObstacleClearSmoke : MonoBehaviour
{
    [SerializeField] private float timeAlive;
    private float time = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if (time >= timeAlive)
        {
            Destroy(gameObject);
        }
    }
}