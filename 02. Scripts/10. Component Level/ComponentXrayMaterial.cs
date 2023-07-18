using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentXrayMaterial : MonoBehaviour
{
    [HideInInspector]
    public bool isChange;
    public Material change;

    private GameObject[] xrayObject;
    private Material[] origin;
    private MeshRenderer[] renderer;
    void Awake()
    {
        xrayObject = GameObject.FindGameObjectsWithTag("Xray");
        origin = new Material[xrayObject.Length];
        renderer = new MeshRenderer[xrayObject.Length];
        for (int i = 0; i < xrayObject.Length; i++)
        {
            origin[i] = xrayObject[i].GetComponent<MeshRenderer>().material;
            renderer[i] = xrayObject[i].GetComponent<MeshRenderer>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isChange)
        {
            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].material = change;
            }

        }
        else
        {
            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].material = origin[i];
            }

        }
    }

    public void Xray()
    {
        isChange = !isChange;
    }
}
