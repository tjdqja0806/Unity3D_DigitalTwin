using UnityEngine;

public class PlantGlow : MonoBehaviour
{
    public Transform plant;
    public Color color;

    public void PointerEnter()
    {
        SetLayersRecursively(plant, "Glow");
    }

    public void PointerExit()
    {
        SetLayersRecursively(plant, "Default");
    }

    private void SetLayersRecursively(Transform trans, string name)
    {
        SetColorRecursively(trans);
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            SetColorRecursively(child);
            SetLayersRecursively(child, name);
        }
    }

    private void SetColorRecursively(Transform trans)
    {
        var rndr = trans.GetComponent<Renderer>();
        if (rndr != null)
        {
            var propertyBlock = new MaterialPropertyBlock();
            rndr.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_SelectionColor", color);
            rndr.SetPropertyBlock(propertyBlock);
        }
    }
}