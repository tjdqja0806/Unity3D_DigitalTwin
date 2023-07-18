using UnityEngine;

public class MinimapControl : MonoBehaviour
{
    public Transform mainCamera;
    public Transform minimapCamera;
    public Transform minimapCanvas;
    public float height;

    private float height1F = 0.25f;
    private float height2F = 0.35f;
    private float height3F = 0.45f;

    void Awake()
    {

    }

    void FixedUpdate()
    {
        minimapCamera.transform.position = new Vector3(minimapCamera.position.x, mainCamera.position.y + height, minimapCamera.position.z);
        minimapCanvas.transform.position = new Vector3(mainCamera.position.x, mainCamera.position.y, mainCamera.position.z);
        minimapCanvas.transform.rotation = Quaternion.Euler(0, mainCamera.eulerAngles.y, 0);
    }
}