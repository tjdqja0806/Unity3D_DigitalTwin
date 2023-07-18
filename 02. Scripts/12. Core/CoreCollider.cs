using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoreCollider : MonoBehaviour
{
    [Serializable]
    public struct PlantStruct
    {
        public Transform rcb;
    }
    public PlantStruct[] plantStructs;
    public Color colorPlant;
    public GameObject core;

    private string plantName;
    private bool isCoreActive;

    void Awake()
    {
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform.gameObject.name != null) { plantName = hit.transform.gameObject.name; }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider != null)
                {
                    switch (plantName)
                    {
                        case "RCB_Grp":
                            isCoreActive = !isCoreActive;
                            break;
                    }
                }
            }

            switch (plantName)
            {
                case "RCB_Grp":
                    SetLayersRecursively(plantStructs[0].rcb, colorPlant, "Glow");
                    break;
                default:
                    //PointerExit();
                    SetLayersRecursively(plantStructs[0].rcb, Color.white, "Default");
                    break;
            }
        }
        core.SetActive(isCoreActive);
    }

    public void PointerExit()
    {
        for (int i = 0; i < plantStructs.Length; i++)
        {
            SetLayersRecursively(plantStructs[i].rcb, Color.white, "Default");
        }
    }

    private void SetLayersRecursively(Transform trans, Color color, string name)
    {
        SetColorRecursively(trans, color);
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            SetColorRecursively(child, color);
            SetLayersRecursively(child, color, name);
        }
    }

    private void SetColorRecursively(Transform trans, Color color)
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
