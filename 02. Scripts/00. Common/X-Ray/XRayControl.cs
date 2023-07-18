using UnityEngine;

public class XRayControl : MonoBehaviour
{
    public GameObject su1;
    [HideInInspector]
    public bool isXRay = false;

    public void _ClickXRay()
    {
        isXRay = !isXRay;
        GameObjectRecursively(su1);
    }

    private void GameObjectRecursively(GameObject objs)
    {
        CheckAndChangeMaterial(objs);
        foreach (Transform child in objs.transform)
        {
            CheckAndChangeMaterial(child.gameObject);
            GameObjectRecursively(child.gameObject);
        }
    }

    private void CheckAndChangeMaterial(GameObject obj)
    {
        var xRayMat = obj.GetComponent<XRayMat>();
        if (xRayMat != null && xRayMat.isActiveAndEnabled)
        {
            xRayMat.ChangeMaterial();
        }
    }
}