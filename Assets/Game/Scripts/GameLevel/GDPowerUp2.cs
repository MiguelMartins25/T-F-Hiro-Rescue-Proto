using UnityEngine;

public class GDPowerUp2 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int increaseAmount;
    private PlayerThomas playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = player.GetComponent<PlayerThomas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D()
    {
        playerScript.ChangeMaxAcceleration(increaseAmount);
        this.gameObject.SetActive(false);
    }
}
