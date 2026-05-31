using UnityEngine;

public class CameraT : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    [SerializeField] BoxCollider2D cameraLimits;
    private Transform cameraTarget;
    private Vector3 vel = Vector3.zero;
    private new Camera camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (cameraTarget == null) return;
            Vector3 desiredPos = cameraTarget.position + offset;

        if (cameraLimits != null)
        {
            Bounds r = cameraLimits.bounds;

            float halfHeight = camera.orthographicSize;
            float halfWidth = camera.aspect * halfHeight;

            desiredPos.x = Mathf.Clamp(desiredPos.x, r.min.x + halfWidth, r.max.x - halfWidth);
            desiredPos.y = Mathf.Clamp(desiredPos.y, r.min.y + halfHeight, r.max.y - halfHeight);
        }

        transform.position = Vector3.Lerp(transform.position, desiredPos, damping * Time.deltaTime);
    } 

    public void SetCameraTarget(Transform target)
    {
        cameraTarget = target;
    }

    public void SetCameraBounds(BoxCollider2D bounds)
    {
        cameraLimits = bounds;
    }
}
