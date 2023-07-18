using UnityEngine;

public class BoxLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform start;
    public Transform end;

    void Start()
    {
        lineRenderer.SetPosition(0, start.position);
        lineRenderer.SetPosition(1, end.position);
    }
}