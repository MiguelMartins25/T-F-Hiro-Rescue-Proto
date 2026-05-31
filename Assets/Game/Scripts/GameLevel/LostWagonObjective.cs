using UnityEngine;

public class LostWagonObjective : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private LostWagon wagonScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wagonScript = player.gameObject.GetComponent<LostWagon>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D()
    {
        wagonScript.OnObjectivePickUp(true);
        this.gameObject.SetActive(false);
    }
}
