using UnityEngine;

public class CameraT : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    private Transform cameraTarget;
    private Vector3 vel = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = cameraTarget.position + offset;

        cameraTarget.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
        targetPosition.z = transform.position.z;
    }

    public void SetCameraTarget(Transform target)
    {
        cameraTarget = target;
        Debug.Log("target set");
    }
}
