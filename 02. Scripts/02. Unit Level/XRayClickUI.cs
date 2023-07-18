using UnityEngine;

public class XRayClickUI : MonoBehaviour
{
    private UnitLevelControl unitLevelControl;

    public XRayControl xRayControl;
    public GameObject worldCanvas;
    public GameObject tempDiagram;
    public GameObject dataCanvas;

    void Awake()
    {
        unitLevelControl = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();
    }
    void Update()
    {
        if (unitLevelControl.isTourActive && xRayControl.isXRay) { worldCanvas.SetActive(false); }
        else { worldCanvas.SetActive(true); }

        if (xRayControl.isXRay) { tempDiagram.SetActive(true); }
        else { tempDiagram.SetActive(false); }

        if (!unitLevelControl.isTourActive) { dataCanvas.SetActive(false); }
        else { dataCanvas.SetActive(true); }
    }
}