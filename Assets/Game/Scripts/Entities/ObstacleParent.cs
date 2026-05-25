using Unity.VisualScripting;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    private bool whistle = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in transform)
        {
            Obstacle controller = child.GetComponent<Obstacle>();
            controller.DestroyObject(whistle);
        }

    }

    public void WhistleVerification(bool enable)
    {
        whistle = enable;
    }
}
