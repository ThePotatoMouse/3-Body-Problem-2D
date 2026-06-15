using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private float camScroll;
    ManagerScript managerScript;

    private void Start()
    {
        cam = Camera.main;
        cam.orthographic = true;
        managerScript = GetComponent<ManagerScript>();
    }

    private void Update()
    {
        if (!managerScript.settingVelocity)
        {
            if (cam.orthographicSize >= 0)
            {
                cam.orthographicSize -= Input.mouseScrollDelta.y * camScroll;
            }
            else
            {
                cam.orthographicSize = 0;
            }
        }

    }
}
