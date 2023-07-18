using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDecomposition : MonoBehaviour
{
    public CanvasGroup tag;
    private float CameraZDistance;

    private ComponentScreenMode script;

    void Awake()
    {
        CameraZDistance = Camera.main.WorldToScreenPoint(transform.position).z;
        script = GameObject.Find("EventSystem").GetComponent<ComponentScreenMode>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            tag.alpha = 0;

    }

    void OnMouseDrag()
    {
        if (script.isFullScreen)
        {
            tag.alpha = 1;
            Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance);
            Vector3 NewWorldPosition = Camera.main.ScreenToWorldPoint(ScreenPosition);
            transform.position = NewWorldPosition;
        }
    }

    // https://www.youtube.com/watch?v=0yHBDZHLRbQ

}