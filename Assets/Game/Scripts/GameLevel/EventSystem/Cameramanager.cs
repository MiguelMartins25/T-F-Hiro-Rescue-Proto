using UnityEngine;

public class Cameramanager : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    private CameraT camerat;
    private bool cameratarget = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        camerat = Camera.GetComponent<CameraT>();
        camerat.SetCameraTarget(target1);
    }

    public void CameraTarget(bool target)
{
    cameratarget = target;

    if (target)
        camerat.SetCameraTarget(target2);
    else
        camerat.SetCameraTarget(target1);
}
}
