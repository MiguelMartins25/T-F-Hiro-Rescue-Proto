using UnityEngine;

public class Cameramanager : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        CameraT camera = Camera.GetComponent<CameraT>();
        camera.SetCameraTarget(target1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
